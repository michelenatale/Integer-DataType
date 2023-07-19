

using michele.natale.Numbers;
using System.Numerics;
using System.Runtime.InteropServices;

namespace TestUIntX;


using static Randomholder;


public class TestInt512Ex
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
    var size_of = sizeof(Int512Ex);

    var type_size = Marshal.SizeOf<Int512Ex>();
  }

  private static void TestInstance()
  {
    var instance = new Int512Ex();


    //unsigned 
    uint ui32 = 5;
    instance = new Int512Ex(ui32);


    //signed 
    int i32 = 5;
    instance = new Int512Ex(i32);

    instance = new Int512Ex(-i32);
  }

  private static void TestConverts()
  {

    //unchecked

    uint ui32 = 5;
    var instance = (Int512Ex)ui32;

    int i32 = 5;
    instance = (Int512Ex)(i32);
    i32 = -i32;
    instance = (Int512Ex)(i32);


    float flt = 5f;
    instance = (Int512Ex)flt;
    flt = -flt;
    instance = (Int512Ex)flt;

    double dbl = 5.0;
    instance = (Int512Ex)(dbl);
    dbl = -dbl;
    instance = (Int512Ex)(dbl);

    decimal dec = 5m;
    instance = (Int512Ex)(dec);
    dec = -dec;
    instance = (Int512Ex)(dec);


    //checked  

    i32 = 5;
    instance = checked((Int512Ex)(i32));
    i32 = -i32;
    instance = checked((Int512Ex)(i32));

    flt = 5f;
    instance = checked((Int512Ex)flt);

    flt = -flt;
    instance = checked((Int512Ex)(flt));

    dec = 5m;
    instance = checked((Int512Ex)dec);
    dec = -dec;
    instance = checked((Int512Ex)(dec));

    dbl = 5.0;
    instance = checked((Int512Ex)dbl);
    dbl = -dbl;
    instance = checked((Int512Ex)(dbl));
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
    var instance = new Int512Ex(lo_hi);

    var bytes = instance.ToBytes();

    bytes = instance.ToBytes(false);

    var values = instance.ToValues();

    values = instance.ToValues(false);

    var uints = instance.ToUInts();

    uints = instance.ToUInts(false);
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
    var instance = new Int512Ex(lo_hi);

    var binstr = instance.ToString(2);
    var octstr = instance.ToString(8);
    var decstr = instance.ToString(10);
    var hexstr = instance.ToString(16);

    var i128 = Int512Ex.Parse(decstr, 10);

    i128 = Int512Ex.Parse(binstr, 2);

    i128 = Int512Ex.Parse(octstr, 8);

    i128 = Int512Ex.Parse(hexstr, 16);
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
    var instance = new Int512Ex(lo_hi);

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
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance = new Int512Ex(lo_hi);

    var binstr = instance.ToString(2);
    var octstr = instance.ToString(8);
    var decstr = instance.ToString(10);
    var hexstr = instance.ToString(16);

    var instance_1 = Int512Ex.Parse(binstr, 2);

    var instance_2 = Int512Ex.Parse(octstr, 8);

    var instance_3 = Int512Ex.Parse(decstr, 10);

    var instance_4 = Int512Ex.Parse(hexstr, 16);

    //bin
    int cap = Convert.ToInt32(Int512Ex.TypeSize * 8) + 1;
    var bytes = Enumerable.Range(0, Rand.Next(2, cap)).Select(x => (byte)Rand.Next(0, 2)).ToArray();
    bytes = TrimFirstSetOneZero(bytes);
    var bits = string.Join("", bytes);
    var i512 = Int512Ex.Parse(bits, 2);
    var strbits = i512.ToString(2);

    //Oct-Systeme können nicht frei gerandomt werden.
    bytes = Enumerable.Range(0, Rand.Next(2, cap)).Select(x => (byte)Rand.Next(0, 2)).ToArray();
    bytes = TrimFirstSetOneZero(bytes);
    bits = string.Join("", bytes);
    i512 = Int512Ex.Parse(bits, 2);

    var oct = i512.ToString(8);
    bits = string.Join("", oct);
    i512 = Int512Ex.Parse(bits, 8);
    strbits = i512.ToString(8);


    //dec
    cap = 1 + (int)double.Truncate(Math.Log10(Math.Pow(2, Int512Ex.TypeSize * 8)));
    bytes = Enumerable.Range(0, Rand.Next(2, cap))
      .Select(x => (byte)Rand.Next(0, 10)).ToArray();
    bytes = TrimFirstSetOneZero(bytes);
    bits = string.Join("", bytes);
    i512 = Int512Ex.Parse(bits, 10);
    strbits = i512.ToString(10);

    //Hex
    cap = Int512Ex.TypeSize + 1;
    bytes = Enumerable.Range(0, Rand.Next(2, cap))
      .Select(x => (byte)Rand.Next(0, 16)).ToArray();

    var hex = "0123456789ABCDEF";
    bytes = TrimFirstSetOneZero(bytes);
    //Normally 2 places per byte. But I leave it like this now.
    bits = string.Join("", bytes.Select(s => hex[s]));
    i512 = Int512Ex.Parse(bits, 16);
    strbits = i512.ToString(16);
  }

  private static void TestBitwiseNot()
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
    var instance = new Int512Ex(lo_hi);

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
    var instance = new Int512Ex(lo_hi);

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
    var instance = new Int512Ex(lo_hi);

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
    var instance = new Int512Ex(lo_hi);

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
    var instance = new Int512Ex(lo_hi);

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
    var instance = new Int512Ex(lo_hi);

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
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance = new Int512Ex(lo_hi);

    if (instance == Int512Ex.MaxValue) instance++;

    if (instance == Int512Ex.MaxValue)
      throw new ArgumentException(null);


    if (instance == Int512Ex.MinValue) instance++;

    if (instance == Int512Ex.MinValue)
      throw new ArgumentException(null);

    instance = 0;
    instance--;

    if (instance == Int512Ex.MaxValue) instance++;

    if (instance == Int512Ex.MaxValue)
      throw new ArgumentException(null);

    if (instance == Int512Ex.MinValue) instance++;

    if (instance == Int512Ex.MinValue)
      throw new ArgumentException(null);
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
    var instance1 = new Int512Ex(lo_hi);
    var instance2 = new Int512Ex(lo_hi);

    if (!instance1.Equals(instance2))
      throw new ArgumentException(null);

    var ainstance1 = new Int512Ex[]
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
    var instance1 = new Int512Ex(lo_hi);
    var instance2 = new Int512Ex(lo_hi);

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
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance = new Int512Ex(lo_hi);

    if (instance == Int512Ex.MaxValue) instance++;

    if (instance == Int512Ex.MaxValue)
      throw new ArgumentException(null);

    if (instance == Int512Ex.MinValue) instance++;

    if (instance == Int512Ex.MinValue)
      throw new ArgumentException(null);
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
    var instance1 = new Int512Ex(lo_hi);

    var uii = (uint)(Rand.NextInt64() * Rand.NextInt64());
    instance1 += uii;

    var lg = Rand.NextInt64() * Rand.NextInt64();
    instance1 += lg;
    lg = -lg;
    instance1 += lg;
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
    var instance1 = new Int512Ex(lo_hi);

    var uii = (uint)(Rand.NextInt64() * Rand.NextInt64());

    var lg = Rand.NextInt64() * Rand.NextInt64();

    instance1 -= uii;

    instance1 -= lg;
    lg = -lg;
    instance1 -= lg;
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
    var instance1 = new Int512Ex(lo_hi);

    var uii = (uint)(Rand.NextInt64() * Rand.NextInt64());

    var lg = Rand.NextInt64() * Rand.NextInt64();

    instance1 *= uii;

    instance1 *= lg;
    lg = -lg;
    instance1 *= lg;
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
    var instance1 = new Int512Ex(lo_hi);

    var uii = (uint)(Rand.NextInt64() * Rand.NextInt64());

    var lg = Rand.NextInt64() * Rand.NextInt64();

    if (uii == 0) uii = 1;
    instance1 /= uii;

    v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    instance1 = new Int512Ex(lo_hi);


    if (lg == 0) lg = 1;
    instance1 /= lg;

    lg = -lg;
    instance1 /= lg;
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
    var instance1 = new Int512Ex(lo_hi);

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
    var v0 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v3 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v4 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v5 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v6 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var v7 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { v0, v1, v2, v3, v4, v5, v6, v7 };
    var instance = new Int512Ex(-15);
    var bi = new BigInteger(-15);
    var e = Rand.Next(0, 15);
    var bipow = BigInteger.Pow(bi, e);
    var pow = Int512Ex.Pow(instance, e);

    instance = new Int512Ex(lo_hi);
    e = Rand.Next(0, 15);
    pow = Int512Ex.Pow(instance, e);

    e = Rand.Next(0, 128);
    var p2 = Int512Ex.PowerOfTwo(e, out var overflow);
    if (overflow) throw new ArgumentException(null);

    if (!Int512Ex.IsPowerTwo(p2))
      throw new ArgumentException(null);

    e = Rand.Next(0, 39);
    var p10 = Int512Ex.PowerOfTen(e, out overflow);
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
    var instance = new Int512Ex(lo_hi);

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



