using System.Collections;

namespace swf_lib {
    public class BitUtilities {
        public static Int32 ReadInt(byte[] data, int offset, int count) {
            List<bool> bitstream = new List<bool>(data.Length);

            for (int i = 0; i < data.Length; i++) {
                for (int j = 0; j < 8; j++) {
                    bitstream.Add(Convert.ToBoolean((data[i] >> (7 - j)) & 1));
                }
            }

            bitstream.RemoveRange(count + offset, bitstream.Count - (count + offset));
            bitstream.RemoveRange(0, offset);

            bitstream.Reverse();

            BitArray bitarray = new BitArray(bitstream.ToArray());

            UInt32[] array = new UInt32[1];
            bitarray.CopyTo(array, 0);
            UInt32 r = array[0];

            return (int)r;
        }
    }

    public class SWFrect {
        public uint minX;
        public uint maxX;
        public uint minY;
        public uint maxY;

        public SWFrect(byte[] data) {
            bool[] bitstream = new bool[data.Length * 8];

            for (int i = 0; i < data.Length; i++) {
                for (int j = 0; j < 8; j++) {
                    bitstream[i * 8 + j] = Convert.ToBoolean((data[i] >> (7 - j)) & 1);
                }
            }

            int size = BitUtilities.ReadInt(data, 0, 5);

            minX = 0;
            for (int i = 0; i < size; i++) {
                if (bitstream[i + 5]) {
                    minX |= (uint)1 << (size - i);
                }
            }

            maxX = 0;
            for (int i = 0; i < size; i++) {
                if (bitstream[i + 4 + size]) {
                    maxX |= (uint)1 << (size - i);
                }
            }

            minY = 0;
            for (int i = 0; i < size; i++) {
                if (bitstream[i + 4 + size * 2]) {
                    minY |= (uint)1 << (size - i);
                }
            }

            maxY = 0;
            for (int i = 0; i < size; i++) {
                if (bitstream[i + 4 + size * 3]) {
                    maxY |= (uint)1 << (size - i);
                }
            }
        }

        public static int GetLength(byte firstbyte) {
            return (int)Math.Ceiling((double)(((firstbyte >> 3) * 4) + 5) / 8.0);
        }
    }

    public class SWFtag {
        public bool longlength;
        public ushort type;
        public int length;
        public byte[]? data;

        public SWFtag(byte[] _data) {
            length = GetLength(_data);

            longlength = IsLong(_data);

            type = (ushort)BitUtilities.ReadInt(new byte[] { _data[1], _data[0] }, 0, 10);

            if (longlength)
                data = _data.ToList().GetRange(6, length).ToArray();
            else
                data = _data.ToList().GetRange(2, length).ToArray();
        }

        public static int GetLength(byte[] data) {
            int r = BitUtilities.ReadInt(data, 2, 6);

            if (r >= 63) {
                r = (int)BitConverter.ToInt32(data.ToList().GetRange(2, 4).ToArray());
            }

            return r;
        }

        public static bool IsLong(byte[] data) {
            int r = BitUtilities.ReadInt(data, 2, 6);

            if (r >= 63) {
                return true;
            }

            return false;
        }
    }

    public class SWF {
        // Header
        public string? signature;
        public byte version;
        public uint length;
        public SWFrect? size;
        public float framerate;
        public ushort framecount;

        // Tags
        public List<SWFtag> tags;

        public SWF(byte[] data) {
            signature = System.Text.Encoding.UTF8.GetString(data).Substring(0, 3);
            version = data[3];
            length = BitConverter.ToUInt32(data, 4);

            /* Swf rectangles are the worst thing ever. Super annoying to parse. Took 3 tries to get the right output. The horrible writing of the SWF spec doesn't make it any better
             * 
             * But in short:
             *  first 5 bits (not bytes): size of every value in bits
             *  next N bits: minimum X
             *  next N bits: maximum X
             *  next N bits: minimum Y
             *  next N bits: maximum Y
             *  until next byte: zero'd out
             *  
             *  Whoever came up with this, I hope you died from overdosing on whatever you were on when you made this -pixlie (finxx) */
            byte[] rectData = new byte[SWFrect.GetLength(data[8])];
            Buffer.BlockCopy(data, 8, rectData, 0, SWFrect.GetLength(data[8]));
            size = new SWFrect(rectData);

            framerate = (float)(data[8 + SWFrect.GetLength(data[8]) + 1]);
            framerate += (float)(data[8 + SWFrect.GetLength(data[8])]) / 256.0f;

            framecount = BitConverter.ToUInt16(data, 8 + SWFrect.GetLength(data[8]) + 2);

            List<byte> tagdata = new List<byte>(data.ToList().GetRange(8 + SWFrect.GetLength(data[8]) + 4, data.Length - (8 + SWFrect.GetLength(data[8]) + 4)));

            tags = new List<SWFtag>();

            int i = 0;

            while (true) {
                int length;
                try {
                    length = SWFtag.GetLength(tagdata.GetRange(i, 6).ToArray());
                } catch {
                    length = SWFtag.GetLength(tagdata.GetRange(i, 2).ToArray());
                }
                bool islong = SWFtag.IsLong(tagdata.GetRange(i, 2).ToArray());

                if (islong)
                    tags.Add(new SWFtag(tagdata.GetRange(i, length + 6).ToArray()));
                else
                    tags.Add(new SWFtag(tagdata.GetRange(i, length + 2).ToArray()));

                if (tags[tags.Count - 1].type == 0) break;

                if (islong)
                    i += length + 6;
                else
                    i += length + 2;
            }
        }
    }

    class Program {
        static void Main(string[] args) {
            SWF swf = new SWF(File.ReadAllBytes(args[0]));

            Console.WriteLine("SWF Header:\n  Signature: {0}\n  Version: {1}\n  Length in bytes: {2}\n  Size in twips: [{3}, {4}, {5}, {6}]\n  Framerate: {7}\n  Framecount: {8}\nSWF Tags:", swf.signature, swf.version, swf.length, swf.size.minX, swf.size.minY, swf.size.maxX, swf.size.maxY, swf.framerate, swf.framecount);

            for (int i = 0; i < swf.tags.Count; i++) {
                Console.WriteLine("  Tag Type: {0}, Tag Size: {1}, Long size: {2}", swf.tags[i].type, swf.tags[i].length, swf.tags[i].longlength);
            }
        }
    }
}