

using michele.natale.Numbers;
using System.Runtime.InteropServices;

namespace TestUIntX;


using static Randomholder;


public class TestUInt128Ex
{
  public static void Start()
  {
    //TestNsc();

    TestSizeOf();
    TestInstance();
    TestConverts();

    TestMethodes();
    TestToString();
    TestParse();
    TestParseString();
    TestBitwise();

    TestOperation();
  }


  private static void TestBitwise()
  {
    TestBitwiseNot(); // OneComplement
    TestBitwiseAnd();
    TestBitwiseOr();
    TestBitwiseXor();
    TestBitwiseShift();
  }

  private static void TestOperation()
  {
    TestIsZeroOne();
    TestIsMinMax();
    TestEquals();
    TestGreatLessThan();
    TestIteration();

    TestNumericOperators();
  }

  private static void TestNumericOperators()
  {
    TestAddition();
    TestSubtraction();
    TestMultiplication();
    TestDivision();
    TestModulo();
    TestPow();
    TestNegate();
  }

  private unsafe static void TestSizeOf()
  {
    var size_of = sizeof(UInt128Ex);

    var type_size = Marshal.SizeOf<UInt128Ex>();
  }

  private static void TestInstance()
  {
    var instance = new UInt128Ex();

    //unsigned

    uint ui32 = 5;
    instance = new UInt128Ex(ui32);

    //signed

    int i32 = 5;
    instance = new UInt128Ex(i32);
  }

  private static void TestConverts()
  {

    //unchecked

    ushort ui16 = 5;
    var instance = (UInt128Ex)(ui16);


    float flt = 5f;
    instance = (UInt128Ex)flt;

    flt = -flt;
    instance = (UInt128Ex)flt;

    double dbl = 5.0;
    instance = (UInt128Ex)(dbl);

    decimal dec = -5m;
    instance = (UInt128Ex)(dec);
  }

  private static void TestMethodes()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new UInt128Ex(hi, lo);
    var bspan = instance.ToSpan();

    var bytes = instance.ToBytes();

    bytes = instance.ToBytes(false);

    var values = instance.ToValues();

    values = instance.ToValues(false);

    var ui128 = UInt128Ex.ToUInt128Ex(instance.ToBytes());

    ui128 = UInt128Ex.ToUInt128Ex(instance.ToValues());
  }

  private static void TestToString()
  {

    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new UInt128Ex(lo, hi);
    var binstr = instance.ToString(2);
    var octstr = instance.ToString(8);
    var decstr = instance.ToString(10);
    var hexstr = instance.ToString(16);

    var ui128 = UInt128Ex.FromDualSystem(binstr);

    ui128 = UInt128Ex.FromOctalSystem(octstr);

    ui128 = UInt128Ex.FromDecimalSystem(decstr);

    ui128 = UInt128Ex.FromHexSystem(hexstr);
  }

  private static void TestParse()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var ui218 = new UInt128(hi, lo);
    var instance = new UInt128Ex(hi, lo);
    var ui = (uint)instance;
    var ll = (long)instance;

    if (ui != Convert.ToUInt32(instance)) throw new ArgumentException(null);
    if (ll != Convert.ToInt64(instance)) throw new ArgumentException(null);

    if (ui != (uint)(ui218)) throw new ArgumentException(null);
    if (ll != (long)(ui218)) throw new ArgumentException(null);
  }

  private static void TestParseString()
  {

    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new UInt128Ex(lo, hi);
    var binstr = instance.ToString(2);
    var octstr = instance.ToString(8);
    var decstr = instance.ToString(10);
    var hexstr = instance.ToString(16);

    var ui128_1 = UInt128Ex.Parse(binstr, 2);
    var ui128_2 = UInt128Ex.Parse(octstr, 8);
    var ui128_3 = UInt128Ex.Parse(decstr, 10);
    var ui128_4 = UInt128Ex.Parse(hexstr, 16);

    //bin
    var bytes = Enumerable.Range(0, Rand.Next(2, 129)).Select(x => (byte)Rand.Next(0, 2)).ToArray();
    bytes = TrimFirstSetOneZero(bytes);
    var bits = string.Join("", bytes);
    var ui128 = UInt128Ex.Parse(bits, 2);
    var strbits = ui128.ToString(2);

    //Oct-Systeme können nicht frei gerandomt werden.
    bytes = Enumerable.Range(0, Rand.Next(2, 129)).Select(x => (byte)Rand.Next(0, 2)).ToArray();
    bytes = TrimFirstSetOneZero(bytes);
    bits = string.Join("", bytes);
    ui128 = UInt128Ex.Parse(bits, 2);

    var oct = ui128.ToString(8);
    bits = string.Join("", oct);
    ui128 = UInt128Ex.Parse(bits, 8);
    strbits = ui128.ToString(8);

    //dec
    bytes = Enumerable.Range(0, Rand.Next(2, 38))
      .Select(x => (byte)Rand.Next(0, 10)).ToArray();
    bytes = TrimFirstSetOneZero(bytes);
    bits = string.Join("", bytes);
    ui128 = UInt128Ex.Parse(bits, 10);
    strbits = ui128.ToString(10);

    //Hex
    bytes = Enumerable.Range(0, Rand.Next(2, 33))
      .Select(x => (byte)Rand.Next(0, 16)).ToArray();

    var hex = "0123456789ABCDEF";
    bytes = TrimFirstSetOneZero(bytes);
    bits = string.Join("", bytes.Select(s => hex[s]));
    ui128 = UInt128Ex.Parse(bits, 16);
    strbits = ui128.ToString(16);
  }

  private static void TestBitwiseNot()
  {

    //Complement

    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var ui128 = new UInt128(hi, lo);
    var instance = new UInt128Ex(hi, lo);

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    ui128 += r;
    instance += r;

    var result1 = ~ui128;
    var result2 = ~instance;
  }

  private static void TestBitwiseAnd()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var ui128 = new UInt128(hi, lo);
    var instance = new UInt128Ex(hi, lo);

    var number = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    ui128 += number;
    instance += number;

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    ui128 &= r;
    instance &= r;
  }

  private static void TestBitwiseOr()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var ui128 = new UInt128(hi, lo);
    var instance = new UInt128Ex(hi, lo);

    var number = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    ui128 += number;
    instance += number;

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    ui128 |= r;
    instance |= r;
  }

  private static void TestBitwiseXor()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var ui128 = new UInt128(hi, lo);
    var instance = new UInt128Ex(hi, lo);

    var number = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    ui128 += number;
    instance += number;

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    ui128 ^= r;
    instance ^= r;
  }

  private static void TestBitwiseShift()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var ui128 = new UInt128(hi, lo);
    var instance = new UInt128Ex(hi, lo);

    var number = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    ui128 += number;
    instance += number;

    var l = 1 + (int)double.Truncate(Math.Log10(Math.Pow(2, 128)));
    var r = Rand.Next(0, l);

    ui128 <<= r;
    instance <<= r;


    r = Rand.Next(0, l);

    ui128 >>= r;
    instance >>= r;


    r = Rand.Next(0, l);

    ui128 >>>= r;
    instance >>>= r;
  }

  private static void TestIsZeroOne()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new UInt128Ex(hi, lo);

    if (instance.IsZero) instance++;

    if (instance.IsOne) instance++;

    if (instance.IsMinusOne) instance--;

    instance = 0;
    var bool_1 = instance.IsZero;

    instance++;
    var bool_2 = instance.IsOne;

    instance--; instance--;
    var bool_3 = instance.IsMinusOne;
  }

  private static void TestIsMinMax()
  {

    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new UInt128Ex(hi, lo);

    if (instance == UInt128Ex.MaxValue) instance++;

    if (instance == UInt128Ex.MinValue) instance++;

    instance = 0;
    instance--;

    if (instance == UInt128Ex.MaxValue) instance++;

    if (instance == UInt128Ex.MinValue) instance++;
  }

  private static void TestEquals()
  {

    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance1 = new UInt128Ex(hi, lo);
    var instance2 = new UInt128Ex(hi, lo);

    if (!instance1.Equals(instance2))
      throw new ArgumentException(null);

    var ainstance1 = new UInt128Ex[]
    {
        (ulong)(Rand.NextInt64() * Rand.NextInt64()),
        (ulong)(Rand.NextInt64() * Rand.NextInt64()),
        (ulong)(Rand.NextInt64() * Rand.NextInt64()),
        (ulong)(Rand.NextInt64() * Rand.NextInt64()),
    };

    var ainstance2 = ainstance1.ToArray();

    if (!ainstance1.SequenceEqual(ainstance2))
      throw new ArgumentException(null);

    ainstance2[0] += 1;

    if (ainstance1.SequenceEqual(ainstance2))
      throw new ArgumentException(null);
  }

  private static void TestGreatLessThan()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance1 = new UInt128Ex(hi, lo);
    var instance2 = new UInt128Ex(hi, lo);

    if (instance1 != instance2)
      throw new ArgumentException(null);

    if (instance1++ >= instance2) ;
    else throw new ArgumentException(null);

    if (instance1-- >= instance2) ;
    else throw new ArgumentException(null);

    if (--instance1 <= instance2) ;
    else throw new ArgumentException(null);

    if (--instance1 <= instance2) ;
    else throw new ArgumentException(null);

    instance1 += 10;
    if (instance1 > instance2) ;
    else throw new ArgumentException(null);

    instance1 -= 20;
    if (instance1 < instance2) ;
    else throw new ArgumentException(null);
  }

  private static void TestIteration()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new UInt128Ex();

    instance++;
    instance--;
  }

  private static void TestAddition()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new UInt128Ex(hi, lo);

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    instance += r;
  }

  private static void TestSubtraction()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new UInt128Ex(hi, lo);
    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    instance -= r;
  }

  private static void TestMultiplication()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new UInt128Ex(hi, lo);

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    instance *= r;
  }

  private static void TestDivision()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new UInt128Ex(hi, lo);

    var r = (ulong)Rand.NextInt64();
    instance /= r;

  }

  private static void TestModulo()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new UInt128Ex(hi, lo);

    var r = (ulong)Rand.NextInt64();
    instance %= r;
  }

  private static void TestPow()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new UInt128Ex();

    var e = Rand.Next(0, 15);
    instance = UInt128Ex.Pow(instance, e);

    e = Rand.Next(0, 128);
    var p2 = UInt128Ex.PowerOfTwo(e, out var overflow);
    if (overflow) throw new ArgumentException(null);

    if (!UInt128Ex.IsPowerTwo(p2))
      throw new ArgumentException(null);

    e = Rand.Next(0, 39);
    var p10 = UInt128Ex.PowerOfTwo(e, out overflow);
    if (overflow) throw new ArgumentException(null);
  }

  private static void TestNegate()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new UInt128Ex(hi, lo);

    instance = -instance;
  }

  private static byte[] TrimFirstSetOneZero(ReadOnlySpan<byte> bytes)
  {
    if (bytes.Length < 3) return new byte[2] { 0, 1 };

    var count = 0;
    var length = bytes.Length;
    for (var i = 0; i < length; i++)
      if (bytes[i] == 0) { count++; }
      else break;

    if (count == bytes.Length) return new byte[2] { 0, 1 };
    if (count == 1) return bytes.ToArray();
    if (count == 0) return new byte[1].Concat(bytes.ToArray()).ToArray();
    return bytes.Slice(count - 1, bytes.Length - count + 1).ToArray();
  }
}



