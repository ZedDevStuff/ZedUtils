namespace ZedUtils.Fun
{
    /// <summary>
    /// A bit. Pretty self-explanatory
    /// </summary>
    public struct Bit
    {
        private bool _value = false;
        public Bit(int value)
        {
            if(value == 0) _value = false;
            else if(value == 1) _value = true;
            else _value = false;
        }
        public Bit(bool value) => _value = value;
        public Bit(byte value) => _value = value == 0 ? false : true;
        public Bit(long value) => _value = value == 0 ? false : true;
        public Bit(Int128 value) => _value = value == 0 ? false : true;
        public Bit(uint value) => _value = value == 0 ? false : true;
        public Bit(ulong value) => _value = value == 0 ? false : true;
        public Bit(UInt128 value) => _value = value == 0 ? false : true;

        public override string ToString()
        {
            return _value ? 1.ToString() : 0.ToString();
        }
        public static Bit Parse(string s)
        {
            s = s.Replace(" ","");
            if(s.Length == 1 && (s == "1" || s == "0"))
            {
                return new Bit(s == "1");
            }
            else throw new FormatException($"The input string '{s}' was not in a correct format.");
        }
        public static Bit Parse(char c)
        {
            if(c == '1' || c == '0')
            {
                return new Bit(c == '1');
            }
            else throw new FormatException($"The input char '{c}' was not in a correct format.");
        }
        public static bool TryParse(string s, out Bit result)
        {
            s = s.Replace(" ","");
            if(s.Length == 1 && (s == "1" || s == "0"))
            {
                result = new Bit(s == "1");
                return true;
            }
            else
            {
                result = new Bit(false);
                return false;
            }
        }
        public static bool TryParse(char c, out Bit result)
        {
            if(c == '1' || c == '0')
            {
                result = new Bit(c == '1');
                return true;
            }
            else
            {
                result = new Bit(false);
                return false;
            }
        }
        public static IEnumerable<Bit> ParseBits(string s)
        {
            s = s.Replace(" ","");
            if(s.Any(c => (c != '0' && c != '1')))
            {
                throw new FormatException($"The input string '{s}' was not in a correct format.");
            }
            List<Bit> result = new List<Bit>();
            foreach(char c in s)
            {
                result.Add(Bit.Parse(c));
            }
            return result;
        }
        public static bool TryParseBits(string s, out IEnumerable<Bit> result)
        {
            s = s.Replace(" ","");
            if(s.Any(c => (c != '0' && c != '1')))
            {
                result = new List<Bit>();
                return false;
            }
            else
            {
                result = new List<Bit>();
                foreach(char c in s)
                {
                    result.Append(Bit.Parse(c));
                }
                return true;
            }
        }

        public static implicit operator bool(Bit bit) => bit._value;
        public static implicit operator byte(Bit bit) => bit._value ? (byte)1 : (byte)0;
        public static implicit operator int(Bit bit)  => bit._value ? 1 : 0;
        public static implicit operator long(Bit bit) => bit._value ? 1 : 0;
        public static implicit operator Int128(Bit bit) => bit._value ? 1 : 0;
        public static implicit operator uint(Bit bit) => bit._value ? 1u : 0u;
        public static implicit operator ulong(Bit bit) => bit._value ? 1ul : 0ul;
        public static implicit operator UInt128(Bit bit) => bit._value ? 1ul : 0ul;

        public static implicit operator Bit(bool value) => new Bit(value);
        public static implicit operator Bit(byte value) => new Bit(value);
        public static implicit operator Bit(int value) => new Bit(value);
        public static implicit operator Bit(long value) => new Bit(value);
        public static implicit operator Bit(Int128 value) => new Bit(value);
        public static implicit operator Bit(uint value) => new Bit(value);
        public static implicit operator Bit(ulong value) => new Bit(value);
        public static implicit operator Bit(UInt128 value) => new Bit(value);
    }

    public static class BitExtensions
    {
        public static int ToInt(this IEnumerable<Bit> bits)
        {
            int result = 0;
            int i = 0;
            foreach (var bit in bits.Reverse())
            {
                result += bit ? (int)Math.Pow(2, i) : 0;
                i++;
            }
            return result;
        }
        public static long ToLong(this IEnumerable<Bit> bits)
        {
            long result = 0;
            int i = 0;
            foreach (var bit in bits.Reverse())
            {
                result += bit ? (long)Math.Pow(2, i) : 0;
                i++;
            }
            return result;
        }
        public static Int128 ToInt128(this IEnumerable<Bit> bits)
        {
            Int128 result = 0;
            int i = 0;
            foreach (var bit in bits.Reverse())
            {
                result += bit ? (Int128)Math.Pow(2, i) : 0;
                i++;
            }
            return result;
        }
        public static uint ToUInt(this IEnumerable<Bit> bits)
        {
            uint result = 0;
            int i = 0;
            foreach (var bit in bits.Reverse())
            {
                result += bit ? (uint)Math.Pow(2, i) : 0;
                i++;
            }
            return result;
        }
        public static ulong ToULong(this IEnumerable<Bit> bits)
        {
            ulong result = 0;
            int i = 0;
            foreach (var bit in bits.Reverse())
            {
                result += bit ? (ulong)Math.Pow(2, i) : 0;
                i++;
            }
            return result;
        }
        public static UInt128 ToUInt128(this IEnumerable<Bit> bits)
        {
            UInt128 result = 0;
            int i = 0;
            foreach (var bit in bits.Reverse())
            {
                result += bit ? (UInt128)Math.Pow(2, i) : 0;
                i++;
            }
            return result;
        }
    }
}