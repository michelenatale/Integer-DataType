

using michele.natale.Numbers;
using System.Runtime.InteropServices;

namespace TestUIntX;


using static Randomholder;


public class TestInt128Ex
{
  public static void Start()
  {


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
    var size_of = sizeof(Int128Ex);

    var type_size = Marshal.SizeOf<Int128Ex>();
  }

  private static void TestInstance()
  {
    var instance = new Int128Ex();


    //unsigned 
    uint ui32 = 5;
    instance = new Int128Ex(0, ui32);


    //signed 
    int i32 = 5;
    instance = new Int128Ex(i32);

    instance = new Int128Ex(-i32);
  }

  private static void TestConverts()
  {

    //unchecked

    uint ui32 = 5;
    var instance = (Int128Ex)ui32;

    int i32 = 5;
    instance = (Int128Ex)(i32);
    i32 = -i32;
    instance = (Int128Ex)(i32);


    float flt = 5f;
    instance = (Int128Ex)flt;
    flt = -flt;
    instance = (Int128Ex)flt;

    double dbl = 5.0;
    instance = (Int128Ex)(dbl);
    dbl = -dbl;
    instance = (Int128Ex)(dbl);

    decimal dec = 5m;
    instance = (Int128Ex)(dec);
    dec = -dec;
    instance = (Int128Ex)(dec);


    //checked  

    i32 = 5;
    instance = checked((Int128Ex)(i32));
    i32 = -i32;
    instance = checked((Int128Ex)(i32));

    flt = 5f;
    instance = checked((Int128Ex)flt);

    flt = -flt;
    instance = checked((Int128Ex)(flt));

    dec = 5m;
    instance = checked((Int128Ex)dec);
    dec = -dec;
    instance = checked((Int128Ex)(dec));

    dbl = 5.0;
    instance = checked((Int128Ex)dbl);
    dbl = -dbl;
    instance = checked((Int128Ex)(dbl));
  }

  private static void TestMethodes()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new Int128Ex(hi, lo);

    var bytes = instance.ToBytes();

    bytes = instance.ToBytes(false);

    var values = instance.ToValues();

    values = instance.ToValues(false);
  }

  private static void TestToString()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new Int128Ex(lo, hi);

    var binstr = instance.ToString(2);
    var octstr = instance.ToString(8);
    var decstr = instance.ToString(10);
    var hexstr = instance.ToString(16);

    var i128 = Int128Ex.Parse(decstr,10);

    i128 = Int128Ex.Parse(binstr,2);

    i128 = Int128Ex.Parse(octstr,8);

    i128 = Int128Ex.Parse(hexstr,16);
  }

  private static void TestParse()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new Int128Ex(hi, lo);
    var ui = (uint)instance;
    var ll = (long)instance;

    var sng = (float)instance;
    var dbl = (double)instance;
    var dec = (decimal)instance;

    if (ui != Convert.ToUInt32(instance)) throw new ArgumentException(null);
    if (ll != Convert.ToInt64(instance)) throw new ArgumentException(null);

    if (sng != Convert.ToSingle(instance)) throw new ArgumentException(null);
    if (dbl != Convert.ToDouble(instance)) throw new ArgumentException(null);
    if (dec != Convert.ToDecimal(instance)) throw new ArgumentException(null);

  }

  private static void TestParseString()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new Int128Ex(lo, hi);

    var binstr = instance.ToString(2);
    var octstr = instance.ToString(8);
    var decstr = instance.ToString(10);
    var hexstr = instance.ToString(16);

    var instance_1 = Int128Ex.Parse(binstr, 2);

    var instance_2 = Int128Ex.Parse(octstr, 8);

    var instance_3 = Int128Ex.Parse(decstr, 10);

    var instance_4 = Int128Ex.Parse(hexstr, 16);

    //bin
    var bytes = Enumerable.Range(0, Rand.Next(2, 129)).Select(x => (byte)Rand.Next(0, 2)).ToArray();
    bytes = TrimFirstSetOneZero(bytes);
    var bits = string.Join("", bytes);
    var ui128 = Int128Ex.Parse(bits, 2);
    var strbits = ui128.ToString(2);

    //Oct-Systeme können nicht frei gerandomt werden.
    bytes = Enumerable.Range(0, Rand.Next(2, 129)).Select(x => (byte)Rand.Next(0, 2)).ToArray();
    bytes = TrimFirstSetOneZero(bytes);
    bits = string.Join("", bytes);
    ui128 = Int128Ex.Parse(bits, 2);

    var oct = ui128.ToString(8);
    bits = string.Join("", oct);
    ui128 = Int128Ex.Parse(bits, 8);
    strbits = ui128.ToString(8);


    //dec
    bytes = Enumerable.Range(0, Rand.Next(2, 38))
      .Select(x => (byte)Rand.Next(0, 10)).ToArray();
    bytes = TrimFirstSetOneZero(bytes);
    bits = string.Join("", bytes);
    ui128 = Int128Ex.Parse(bits, 10);
    strbits = ui128.ToString(10);

    //Hex
    bytes = Enumerable.Range(0, Rand.Next(2, 33))
      .Select(x => (byte)Rand.Next(0, 16)).ToArray();

    var hex = "0123456789ABCDEF";
    bytes = TrimFirstSetOneZero(bytes);
    bits = string.Join("", bytes.Select(s => hex[s]));
    ui128 = Int128Ex.Parse(bits, 16);
    strbits = ui128.ToString(16);
  }

  private static void TestBitwiseNot()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new Int128Ex(hi, lo);

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    instance += r;
    var result2 = ~instance;
  }

  private static void TestBitwiseAnd()
  {

    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new Int128Ex(hi, lo);

    var number = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    instance += number;

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    instance &= r;
  }

  private static void TestBitwiseOr()
  {

    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new Int128Ex(hi, lo);

    var number = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    instance += number;

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    instance |= r;
  }

  private static void TestBitwiseXor()
  {


    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new Int128Ex(hi, lo);

    var number = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    instance += number;

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    instance ^= r;

  }

  private static void TestBitwiseShift()
  {

    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new Int128Ex(hi, lo);

    var number = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    instance += number;

    var l = 1 + (int)double.Truncate(Math.Log10(Math.Pow(2, 128)));
    var r = Rand.Next(0, l);
    instance <<= r;

    r = Rand.Next(0, l);
    instance >>= r;

    r = Rand.Next(0, l);
    instance >>>= r;
  }

  private static void TestIsZeroOne()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new Int128Ex(hi, lo);

    if (instance.IsZero) instance++;

    if (instance.IsZero)
      throw new ArgumentException(null);


    if (instance.IsOne) instance++;

    if (instance.IsOne)
      throw new ArgumentException(null);


    if (instance.IsMinusOne) instance--;

    if (instance.IsMinusOne)
      throw new ArgumentException(null);


    instance = 0;
    if (!instance.IsZero)
      throw new ArgumentException(null);

    instance++;
    if (!instance.IsOne)
      throw new ArgumentException(null);

    instance--; instance--;
    if (!instance.IsMinusOne)
      throw new ArgumentException(null);
  }

  private static void TestIsMinMax()
  {

    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new Int128Ex(hi, lo);

    if (instance == Int128Ex.MaxValue) instance++;

    if (instance == Int128Ex.MaxValue)
      throw new ArgumentException(null);


    if (instance == Int128Ex.MinValue) instance++;

    if (instance == Int128Ex.MinValue)
      throw new ArgumentException(null);

    instance = 0;
    instance--;

    if (instance == Int128Ex.MaxValue) instance++;

    if (instance == Int128Ex.MaxValue)
      throw new ArgumentException(null);

    if (instance == Int128Ex.MinValue) instance++;

    if (instance == Int128Ex.MinValue)
      throw new ArgumentException(null);
  }

  private static void TestEquals()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance1 = new Int128Ex(hi, lo);
    var instance2 = new Int128Ex(hi, lo);

    if (!instance1.Equals(instance2))
      throw new ArgumentException(null);

    var ainstance1 = new Int128Ex[]
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

    var instance1 = new Int128Ex(hi, lo);
    var instance2 = new Int128Ex(hi, lo);

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

    var instance = new Int128Ex(hi, lo);

    if (instance == Int128Ex.MaxValue) instance++;

    if (instance == Int128Ex.MaxValue)
      throw new ArgumentException(null);

    if (instance == Int128Ex.MinValue) instance++;

    if (instance == Int128Ex.MinValue)
      throw new ArgumentException(null);
  }

  private static void TestAddition()
  {

    var lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance1 = new Int128Ex(hi1, lo1);

    var uii = (uint)(Rand.NextInt64() * Rand.NextInt64());
    instance1 += uii;

    var lg = Rand.NextInt64() * Rand.NextInt64();
    instance1 += lg;
    lg = -lg;
    instance1 += lg;
  }

  private static void TestSubtraction()
  {
    var lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance1 = new Int128Ex(hi1, lo1);

    var uii = (uint)(Rand.NextInt64() * Rand.NextInt64());

    var lg = Rand.NextInt64() * Rand.NextInt64();

    instance1 -= uii;

    instance1 -= lg;
    lg = -lg;
    instance1 -= lg;
  }

  private static void TestMultiplication()
  {
    var lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance1 = new Int128Ex(hi1, lo1);

    var uii = (uint)(Rand.NextInt64() * Rand.NextInt64());

    var lg = Rand.NextInt64() * Rand.NextInt64();

    instance1 *= uii;

    instance1 *= lg;
    lg = -lg;
    instance1 *= lg;
  }

  private static void TestDivision()
  {
    var lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance1 = new Int128Ex(hi1, lo1);

    var uii = (uint)(Rand.NextInt64() * Rand.NextInt64());

    var lg = Rand.NextInt64() * Rand.NextInt64();

    if (uii == 0) uii = 1;
    instance1 /= uii;

    lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    instance1 = new Int128Ex(hi1, lo1);

    if (lg == 0) lg = 1;
    instance1 /= lg;

    lg = -lg;
    instance1 /= lg;
  }

  private static void TestModulo()
  {
    var lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance1 = new Int128Ex(hi1, lo1);

    var uii = (uint)(Rand.NextInt64() * Rand.NextInt64());

    var lg = Rand.NextInt64() * Rand.NextInt64();

    if (uii == 0) uii = 1;
    instance1 %= uii;

    if (lg == 0) lg = 1;
    instance1 %= lg;
    lg = -lg;
    instance1 %= lg;
  }

  private static void TestPow()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var instance = new Int128Ex(hi, lo);

    var e = Rand.Next(0, 15);
    instance = Int128Ex.Pow(instance, e);

    e = Rand.Next(0, 128);
    var p2 = Int128Ex.PowerOfTwo(e, out var overflow);
    if (overflow) throw new ArgumentException(null);

    if (!Int128Ex.IsPowerTwo(p2))
      throw new ArgumentException(null);

    e = Rand.Next(0, 39);
    var p10 = Int128Ex.PowerOfTen(e, out overflow);
    if (overflow) throw new ArgumentException(null);
  }

  private static void TestNegate()
  {
    var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var ui128 = new Int128(hi, lo);
    var instance = new Int128Ex(hi, lo);

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



