

using michele.natale.Numbers;
using System.Runtime.InteropServices;

namespace TestUIntX;


using static Randomholder;


public class TestUInt512Ex
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
    var size_of = sizeof(UInt512Ex);

    var type_size = Marshal.SizeOf<UInt512Ex>();
  }

  private static void TestInstance()
  {
    var instance = new UInt512Ex();

    //unsigned

    uint ui32 = 5;
    instance = new UInt512Ex(ui32);

    ulong ui64 = 5;
    instance = new UInt512Ex(ui64);

    //signed

    int i32 = 5;
    instance = new UInt512Ex(i32);

    var instance2 = new UInt512Ex(instance);
  }

  private static void TestConverts()
  {

    //unchecked

    ushort ui16 = 5;
    var instance = (UInt512Ex)(ui16);


    float flt = 5f;
    instance = (UInt512Ex)flt;

    flt = -flt;
    instance = (UInt512Ex)flt;

    double dbl = 5.0;
    instance = (UInt512Ex)dbl;

    decimal dec = -5m;
    instance = (UInt512Ex)dec;
  }

  private static void TestMethodes()
  {
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance = new UInt512Ex(lo_hi);


    var bspan = instance.ToSpan();

    var bytes = instance.ToBytes();

    bytes = instance.ToBytes(false);

    var values = instance.ToValues();

    values = instance.ToValues(false);

    var ui128 = UInt512Ex.ToUInt512Ex(instance.ToBytes());

    ui128 = UInt512Ex.ToUInt512Ex(instance.ToValues());
  }

  private static void TestToString()
  {
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance = new UInt512Ex(lo_hi);

    var binstr = instance.ToString(2);
    var octstr = instance.ToString(8);
    var decstr = instance.ToString(10);
    var hexstr = instance.ToString(16);

    var ui512 = UInt512Ex.Parse(binstr,2);

    ui512 = UInt512Ex.Parse(octstr,8);

    ui512 = UInt512Ex.Parse(decstr,10);

    ui512 = UInt512Ex.Parse(hexstr,16);
  }

  private static void TestParse()
  {
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance = new UInt512Ex(lo_hi);

    var ui = (uint)instance;
    var ll = (long)instance;

    if (ui != Convert.ToUInt32(instance)) throw new ArgumentException(null);
    if (ll != Convert.ToInt64(instance)) throw new ArgumentException(null);
  }

  private static void TestParseString()
  {

    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance = new UInt512Ex(lo_hi);

    var binstr = instance.ToString(2);
    var octstr = instance.ToString(8);
    var decstr = instance.ToString(10);
    var hexstr = instance.ToString(16);

    var ui128_1 = UInt512Ex.Parse(binstr, 2);
    var ui128_2 = UInt512Ex.Parse(octstr, 8);
    var ui128_3 = UInt512Ex.Parse(decstr, 10);
    var ui128_4 = UInt512Ex.Parse(hexstr, 16);

    //bin
    var bytes = Enumerable.Range(0, Rand.Next(2, 129)).Select(x => (byte)Rand.Next(0, 2)).ToArray();
    bytes = TrimFirstSetOneZero(bytes);
    var bits = string.Join("", bytes);
    var ui128 = UInt512Ex.Parse(bits, 2);
    var strbits = ui128.ToString(2);

    //Oct-Systeme können nicht frei gerandomt werden.
    bytes = Enumerable.Range(0, Rand.Next(2, 129)).Select(x => (byte)Rand.Next(0, 2)).ToArray();
    bytes = TrimFirstSetOneZero(bytes);
    bits = string.Join("", bytes);
    ui128 = UInt512Ex.Parse(bits, 2);

    var oct = ui128.ToString(8);
    bits = string.Join("", oct);
    ui128 = UInt512Ex.Parse(bits, 8);
    strbits = ui128.ToString(8);

    //dec
    bytes = Enumerable.Range(0, Rand.Next(2, 38))
      .Select(x => (byte)Rand.Next(0, 10)).ToArray();
    bytes = TrimFirstSetOneZero(bytes);
    bits = string.Join("", bytes);
    ui128 = UInt512Ex.Parse(bits, 10);
    strbits = ui128.ToString(10);

    //Hex
    bytes = Enumerable.Range(0, Rand.Next(2, 33))
      .Select(x => (byte)Rand.Next(0, 16)).ToArray();

    var hex = "0123456789ABCDEF";
    bytes = TrimFirstSetOneZero(bytes);
    bits = string.Join("", bytes.Select(s => hex[s]));
    ui128 = UInt512Ex.Parse(bits, 16);
    strbits = ui128.ToString(16);
  }

  private static void TestBitwiseNot()
  {

    //Complement
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance = new UInt512Ex(lo_hi);

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    instance += r;

    var result2 = ~instance;
  }

  private static void TestBitwiseAnd()
  {
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance = new UInt512Ex(lo_hi);

    var number = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    instance += number;

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    instance &= r;
  }

  private static void TestBitwiseOr()
  {
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance = new UInt512Ex(lo_hi);

    var number = (ulong)(Rand.NextInt64() * Rand.NextInt64()); 
    instance += number;

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64()); 
    instance |= r;
  }

  private static void TestBitwiseXor()
  {
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance = new UInt512Ex(lo_hi);
    var number = (ulong)(Rand.NextInt64() * Rand.NextInt64()); 
    instance += number;

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());
 
    instance ^= r;
  }

  private static void TestBitwiseShift()
  {
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance = new UInt512Ex(lo_hi);

    var number = (ulong)(Rand.NextInt64() * Rand.NextInt64()); 
    instance += number;

    var l = 1 + (int)double.Truncate(Math.Log10(Math.Pow(2, 512)));
    var r = Rand.Next(0, l);
 
    instance <<= r;


    r = Rand.Next(0, l);
 
    instance >>= r;


    r = Rand.Next(0, l);
 
    instance >>>= r;
  }

  private static void TestIsZeroOne()
  {
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance = new UInt512Ex(lo_hi);

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
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance = new UInt512Ex(lo_hi);

    if (instance == UInt512Ex.MaxValue) instance++;

    if (instance == UInt512Ex.MinValue) instance++;

    instance = 0;
    instance--;

    if (instance == UInt512Ex.MaxValue) instance++;

    if (instance == UInt512Ex.MinValue) instance++;
  }

  private static void TestEquals()
  {
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance1 = new UInt512Ex(lo_hi);
    var instance2 = new UInt512Ex(lo_hi);

    if (!instance1.Equals(instance2))
      throw new ArgumentException(null);

    var ainstance1 = new UInt512Ex[]
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
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance1 = new UInt512Ex(lo_hi);
    var instance2 = new UInt512Ex(lo_hi);

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
    var instance = new UInt512Ex();

    instance++;
    instance--;
  }

  private static void TestAddition()
  {
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance = new UInt512Ex(lo_hi);

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    instance += r;
  }

  private static void TestSubtraction()
  {
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance = new UInt512Ex(lo_hi);

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    instance -= r;
  }

  private static void TestMultiplication()
  {
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance = new UInt512Ex(lo_hi);

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    instance *= r;
  }

  private static void TestDivision()
  {
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance = new UInt512Ex(lo_hi);

    var r = (ulong)Rand.NextInt64();
    instance /= r;

  }

  private static void TestModulo()
  {
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance = new UInt512Ex(lo_hi);

    var r = (ulong)Rand.NextInt64();
    instance %= r;
  }

  private static void TestPow()
  { 

    var instance = new UInt512Ex(Rand.Next());

    var e = Rand.Next(0, 15);
    instance = UInt512Ex.Pow(instance, e);

    e = Rand.Next(0, 128);
    var p2 = UInt512Ex.PowerOfTwo(e, out var overflow);
    if (overflow) throw new ArgumentException(null);

    if (!UInt512Ex.IsPowerTwo(p2))
      throw new ArgumentException(null);

    e = Rand.Next(0, 39);
    var p10 = UInt512Ex.PowerOfTen(e, out overflow);
    if (overflow) throw new ArgumentException(null); 
  }

  private static void TestNegate()
  {
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance = new UInt512Ex(lo_hi);

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



