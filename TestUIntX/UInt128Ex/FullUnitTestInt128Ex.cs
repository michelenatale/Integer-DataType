
using System.Text;
using System.Numerics;
using michele.natale.Numbers;
using System.Runtime.InteropServices;

namespace TestUIntX;


using static Randomholder;


public class TestFullUnitTestInt128Ex
{
  public static void Start()
  {
    var counts = 1000;

    //TestKontrolle(counts);

    TestSizeOf();
    TestInstance();
    TestConverts();
    TestMethodes(counts);
    TestToString(counts);
    TestParse(counts);
    TestParseString(counts);
    TestBitwise(counts);

    TestOperation(counts);
  }

  private static void TestBitwise(int counts)
  {
    TestBitwiseNot(counts); // OneComplement
    TestBitwiseAnd(counts);
    TestBitwiseOr(counts);
    TestBitwiseXor(counts);
    TestBitwiseShift(counts);
  }

  private static void TestOperation(int counts)
  {
    TestIsZeroOne(counts);
    TestIsMinMax(counts);
    TestEquals(counts);
    TestGreatLessThan(counts);
    TestIteration(counts);

    TestNumericOperators(counts);
  }

  private static void TestNumericOperators(int counts)
  {
    TestAddition(counts);
    TestSubtraction(counts);
    TestMultiplication(counts);
    TestDivision(counts);
    TestModulo(counts);
    TestPow(counts);
    TestNegate(counts);
  }

  private unsafe static void TestKontrolle(int counts)
  {
    for (var i = 0; i < counts; i++)
    {
      var i128 = new Int128(0, (ulong)i);
      var instance = new Int128Ex((ulong)i);
      if (!Equal(instance, i128))
        throw new ArgumentException(null);

      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      i128 = new Int128(hi, lo);
      instance = new Int128Ex(hi, lo);
      var str = instance.ToString();
      if (!Equal(instance, i128))
        throw new ArgumentException(null);

      i128 = new Int128(ulong.MaxValue, ulong.MaxValue - (ulong)i);
      instance = new Int128Ex(ulong.MaxValue, ulong.MaxValue - (ulong)i);
      if (!Equal(instance, i128))
        throw new ArgumentException(null);
    }
  }

  private unsafe static void TestSizeOf()
  {
    var size_of = sizeof(Int128Ex);

    if (size_of != Int128Ex.TypeSize)
      throw new ArgumentException(null);

    var type_size = Marshal.SizeOf<Int128Ex>();

    if (type_size != Int128Ex.TypeSize)
      throw new ArgumentException(null);
  }

  private static void TestInstance()
  {
    var instance = new Int128Ex();
    var str = instance.ToString();


    //unsigned

    byte ui8 = 5;
    instance = new Int128Ex(0, ui8);

    ushort ui16 = 5;
    instance = new Int128Ex(0, ui16);

    uint ui32 = 5;
    instance = new Int128Ex(0, ui32);

    ulong ui64 = 5;
    instance = new Int128Ex(0, ui64);


    //signed

    sbyte i8 = 5;
    instance = new Int128Ex(i8);
    if (!Equal(instance, (Int128)i8))
      throw new ArgumentException(null);
    instance = new Int128Ex(-i8);
    if (!Equal(instance, (Int128)(-i8)))
      throw new ArgumentException(null);

    short i16 = 5;
    instance = new Int128Ex(i16);
    if (!Equal(instance, (Int128)i16))
      throw new ArgumentException(null);
    instance = new Int128Ex(-i16);
    if (!Equal(instance, (Int128)(-i16)))
      throw new ArgumentException(null);

    int i32 = 5;
    instance = new Int128Ex(i32);
    if (!Equal(instance, (Int128)i32))
      throw new ArgumentException(null);
    instance = new Int128Ex(-i32);
    if (!Equal(instance, (Int128)(-i32)))
      throw new ArgumentException(null);

    long i64 = 5;
    instance = new Int128Ex(i64);
    if (!Equal(instance, (Int128)i64))
      throw new ArgumentException(null);
    instance = new Int128Ex(-i64);
    if (!Equal(instance, (Int128)(-i64)))
      throw new ArgumentException(null);

    var cnt = 100;
    for (var i = 0; i < cnt; i++)
    {
      var lo = Rand.NextInt64();
      var hi = Rand.NextInt64();
      instance = new Int128Ex(lo);
      if (!Equal(instance, (Int128)lo))
        throw new ArgumentException(null);
      instance = new Int128Ex(-lo);
      if (!Equal(instance, (Int128)(-lo)))
        throw new ArgumentException(null);

      instance = new Int128Ex((ulong)hi, (ulong)lo);
      if (!Equal(instance, new Int128((ulong)hi, (ulong)lo)))
        throw new ArgumentException(null);
      instance = new Int128Ex((ulong)-hi, (ulong)-lo);
      if (!Equal(instance, new Int128((ulong)-hi, (ulong)-lo)))
        throw new ArgumentException(null);
    }
  }

  private static void TestConverts()
  {

    //unchecked

    byte ui8 = 5;
    var instance = (Int128Ex)ui8;
    if (!Equal(instance, (Int128)ui8))
      throw new ArgumentException(null);

    ushort ui16 = 5;
    instance = (Int128Ex)(ui16);
    if (!Equal(instance, (Int128)ui16))
      throw new ArgumentException(null);

    uint ui32 = 5;
    instance = (Int128Ex)(ui32);
    if (!Equal(instance, (Int128)ui32))
      throw new ArgumentException(null);

    ulong ui64 = 5;
    instance = (Int128Ex)(ui64);
    if (!Equal(instance, (Int128)ui64))
      throw new ArgumentException(null);

    sbyte i8 = 5;
    instance = (Int128Ex)i8;
    if (!Equal(instance, (Int128)i8))
      throw new ArgumentException(null);
    i8 = (sbyte)-i8;
    instance = (Int128Ex)i8;
    if (!Equal(instance, (Int128)i8))
      throw new ArgumentException(null);

    short i16 = 5;
    instance = (Int128Ex)i16;
    if (!Equal(instance, (Int128)i16))
      throw new ArgumentException(null);
    i16 = (short)-i16;
    instance = (Int128Ex)i16;
    if (!Equal(instance, (Int128)i16))
      throw new ArgumentException(null);

    int i32 = 5;
    instance = (Int128Ex)(i32);
    if (!Equal(instance, (Int128)i32))
      throw new ArgumentException(null);
    i32 = -i32;
    instance = (Int128Ex)(i32);
    if (!Equal(instance, (Int128)i32))
      throw new ArgumentException(null);

    long i64 = 5;
    instance = (Int128Ex)i64;
    if (!Equal(instance, (Int128)i64))
      throw new ArgumentException(null);
    i64 = -i64;
    instance = (Int128Ex)i64;
    if (!Equal(instance, (Int128)i64))
      throw new ArgumentException(null);


    float flt = 5f;
    instance = (Int128Ex)flt;
    if (!Equal(instance, (Int128)flt))
      throw new ArgumentException(null);
    flt = -flt;
    instance = (Int128Ex)flt;

    //Int128 gibt hier ein 0 zurück.
    //Meiner Ansicht nach ist das falsch, 
    //es muss der gleiche Wert ergeben wie -5
    if (!Equal(instance, (Int128)i64))
      throw new ArgumentException(null);

    double dbl = 5.0;
    instance = (Int128Ex)(dbl);
    if (!Equal(instance, (Int128)dbl))
      throw new ArgumentException(null);
    dbl = -dbl;
    instance = (Int128Ex)(dbl);
    if (!Equal(instance, (Int128)i64))
      throw new ArgumentException(null);

    decimal dec = 5m;
    instance = (Int128Ex)(dec);
    if (!Equal(instance, (Int128)dec))
      throw new ArgumentException(null);
    dec = -dec;
    instance = (Int128Ex)(dec);
    if (!Equal(instance, (Int128)i64))
      throw new ArgumentException(null);



    //checked

    ui8 = 5;
    instance = checked((Int128Ex)ui8);
    if (!Equal(instance, checked((Int128)ui8)))
      throw new ArgumentException(null);

    ui16 = 5;
    instance = checked((Int128Ex)ui16);
    if (!Equal(instance, checked((Int128)ui16)))
      throw new ArgumentException(null);

    ui32 = 5;
    instance = checked((Int128Ex)ui32);
    if (!Equal(instance, checked((Int128)ui32)))
      throw new ArgumentException(null);

    ui64 = 5;
    instance = checked((Int128Ex)ui64);
    if (!Equal(instance, checked((Int128)ui64)))
      throw new ArgumentException(null);

    i8 = 5;
    instance = checked((Int128Ex)(i8));
    if (!Equal(instance, checked((Int128)i8)))
      throw new ArgumentException(null);
    i8 = (sbyte)-i8;
    instance = checked((Int128Ex)(i8));
    if (!Equal(instance, checked((Int128)(i8))))
      throw new ArgumentException(null);

    i16 = 5;
    instance = checked((Int128Ex)(i16));
    if (!Equal(instance, checked((Int128)i16)))
      throw new ArgumentException(null);
    i16 = (short)-i16;
    instance = checked((Int128Ex)(i16));
    if (!Equal(instance, checked((Int128)(i16))))
      throw new ArgumentException(null);

    i32 = 5;
    instance = checked((Int128Ex)(i32));
    if (!Equal(instance, checked((Int128)i32)))
      throw new ArgumentException(null);
    i32 = -i32;
    instance = checked((Int128Ex)(i32));
    if (!Equal(instance, checked((Int128)(i32))))
      throw new ArgumentException(null);

    i64 = 5;
    instance = checked((Int128Ex)(i64));
    if (!Equal(instance, checked((Int128)i64)))
      throw new ArgumentException(null);
    i64 = -i64;
    instance = checked((Int128Ex)(i64));
    if (!Equal(instance, checked((Int128)(i64))))
      throw new ArgumentException(null);


    flt = 5f;
    instance = checked((Int128Ex)flt);
    if (!Equal(instance, checked((Int128)flt)))
      throw new ArgumentException(null);

    flt = -flt;
    instance = checked((Int128Ex)(flt));

    //Int128 gibt hier ein 0 zurück.
    //Meiner Ansicht nach ist das falsch, 
    //es muss der gleiche Wert ergeben wie -5
    if (!Equal(instance, checked((Int128)(i64))))
      throw new ArgumentException(null);

    //Bemerkung: float kann grösser werden als 2^127

    dec = 5m;
    instance = checked((Int128Ex)dec);
    if (!Equal(instance, checked((Int128)dec)))
      throw new ArgumentException(null);
    dec = -dec;
    instance = checked((Int128Ex)(dec));
    if (!Equal(instance, checked((Int128)(i64))))
      throw new ArgumentException(null);

    //Bemerkung: decimal kann grösser werden als 2^127


    dbl = 5.0;
    instance = checked((Int128Ex)dbl);
    if (!Equal(instance, checked((Int128)dbl)))
      throw new ArgumentException(null);

    dbl = -dbl;
    instance = checked((Int128Ex)(dbl));
    if (!Equal(instance, checked((Int128)(i64))))
      throw new ArgumentException(null);

    dbl = 340282366920938463463374607431768211456.0;
    //instance = checked((Int128Ex)(dbl));
    //if (!Equal(instance, checked((Int128)(dbl))))
    //  throw new ArgumentException(null);


    var cnt = 100;
    for (var i = 0; i < cnt; i++)
    {
      dbl = Rand.NextDouble() * 340282366920938463463374607431768211456.0;
      ui8 = (byte)dbl;
      instance = (Int128Ex)(ui8);
      if (!Equal(instance, (Int128)ui8))
        throw new ArgumentException(null);

      ui16 = (ushort)dbl;
      instance = (Int128Ex)(ui16);
      if (!Equal(instance, (Int128)ui16))
        throw new ArgumentException(null);

      ui32 = (uint)dbl;
      instance = (Int128Ex)(ui32);
      if (!Equal(instance, (Int128)ui32))
        throw new ArgumentException(null);

      ui64 = (ulong)dbl;
      instance = (Int128Ex)(ui64);
      if (!Equal(instance, (Int128)ui64))
        throw new ArgumentException(null);

      i8 = (sbyte)dbl;
      instance = (Int128Ex)(i8);
      if (!Equal(instance, (Int128)i8))
        throw new ArgumentException(null);
      i8 = (sbyte)-i8;
      instance = (Int128Ex)(i8);
      if (!Equal(instance, (Int128)i8))
        throw new ArgumentException(null);

      i16 = (short)dbl;
      instance = (Int128Ex)(i16);
      if (!Equal(instance, (Int128)i16))
        throw new ArgumentException(null);
      i16 = (short)-i16;
      instance = (Int128Ex)(i16);
      if (!Equal(instance, (Int128)i16))
        throw new ArgumentException(null);

      i32 = (int)dbl;
      instance = (Int128Ex)(i32);
      if (!Equal(instance, (Int128)i32))
        throw new ArgumentException(null);
      i32 = -i32;
      instance = (Int128Ex)(i32);
      if (!Equal(instance, (Int128)i32))
        throw new ArgumentException(null);

      i64 = (long)dbl;
      instance = (Int128Ex)(i64);
      if (!Equal(instance, (Int128)i64))
        throw new ArgumentException(null);
      i64 = -i64;
      instance = (Int128Ex)(i64);
      if (!Equal(instance, (Int128)i64))
        throw new ArgumentException(null);

      var bi = new BigInteger(dbl);
      bi = (bi % (1 + (BigInteger)float.MaxValue));
      flt = (float)bi;
      var bflt = ToI128((BigInteger)flt);
      instance = (Int128Ex)(flt);
      var bibi = (Int128)bflt;
      //if (!Equal(instance, (Int128)flt))
      //  //Sobald es grosse Zahlen sind, die ins minus fallen,
      //  //gibt Int128 ein falscher Wert aus (Wert ist sagar positiv)
      //  throw new ArgumentException(null);
      if (!Equal(instance, bibi))
        throw new ArgumentException(null);
      flt = -flt;
      bflt = ToI128((BigInteger)flt);
      instance = (Int128Ex)flt;
      bibi = (Int128)bflt;

      ////gibt wiederum ein falscher Wert aus.
      //if (!Equal(instance, (Int128)(flt)))
      //  throw new ArgumentException(null);
      if (!Equal(instance, bibi))
        throw new ArgumentException(null);

      var dbi = new BigInteger(dbl);
      var dblli2 = ToI128(dbi);
      //var dblli2 = dbi % (BigInteger.One << 128);
      //var dblli3 = (-dbi % (BigInteger.One << 128)) + (BigInteger.One << 128);

      instance = (Int128Ex)dbl;
      if (!Equal(instance, dblli2))
        throw new ArgumentException(null);
      dbl = -dbl;
      instance = (Int128Ex)dbl;
      var dblli3 = ToI128((BigInteger)dbl);
      if (!Equal(instance, dblli3))
        throw new ArgumentException(null);

      var decbi1 = new BigInteger(dbl) % (BigInteger.One << 96);
      var decbi2 = new BigInteger(-dbl) % (BigInteger.One << 96);

      dec = (decimal)(decbi1);
      instance = (Int128Ex)dec;
      var decbi = ToI128(decbi1);
      if (!Equal(instance, decbi))
        throw new ArgumentException(null);
      dec = -dec;
      instance = (Int128Ex)dec;
      decbi = ToI128(decbi2);
      if (!Equal(instance, decbi))
        throw new ArgumentException(null);



      //checked
      //Sobald negative oder zu grosse Zahlen im Spiel sind, wird eine
      //Exception geworfen.

      ui8 = (byte)dbl;
      instance = checked((Int128Ex)ui8);
      if (!Equal(instance, checked((Int128)ui8)))
        throw new ArgumentException(null);

      ui16 = (ushort)dbl;
      instance = checked((Int128Ex)ui16);
      if (!Equal(instance, checked((Int128)ui16)))
        throw new ArgumentException(null);

      ui32 = (uint)dbl;
      instance = checked((Int128Ex)ui32);
      if (!Equal(instance, checked((Int128)ui32)))
        throw new ArgumentException(null);

      ui64 = (ulong)dbl;
      instance = checked((Int128Ex)ui64);
      if (!Equal(instance, checked((Int128)ui64)))
        throw new ArgumentException(null);

      //flt = (float)dbl;
      //var f = (BigInteger)float.MaxValue;
      //instance = checked((Int128Ex)(flt));
      ////if (!Equal(instance, checked((Int128)(flt))))
      ////  throw new ArgumentException(null); 

      ////Bemerkung: float kann grösser werden als 2^127

      //decbi1 = new BigInteger(dbl) % (BigInteger.One << 96);
      //decbi2 = new BigInteger(-dbl) % (BigInteger.One << 96);
      //dec = (decimal)(decbi1);
      //instance = checked((Int128Ex)(dec));
      //if (!Equal(instance, checked((Int128)dec)))
      //  throw new ArgumentException(null);

      ////Bemerkung: decimal kann nicht grösser werden als 2^127

      //dbl %= 340282366920938463463374607431768211456.0;
      //instance = checked((Int128Ex)(dbl));
      //if (!Equal(instance, checked((Int128)dbl)))
      //  throw new ArgumentException(null);

      //dbl = flt;
      //instance = checked((Int128Ex)(dbl));
      //if (!Equal(instance, checked((Int128)dbl)))
      //  throw new ArgumentException(null);
    }
  }

  private static void TestMethodes(int counts)
  {

    for (var i = 0; i < counts; i++)
    {

      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var lo_h0 = new ulong[] { lo, 0 };
      var lo_hi = new ulong[] { lo, hi };

      var lo_h0_bytes = new byte[Int128Ex.TypeSize];
      var lo_hi_bytes = new byte[Int128Ex.TypeSize];
      var lo_h0_uints = new uint[Int128Ex.TypeSize / 4];
      var lo_hi_uints = new uint[Int128Ex.TypeSize / 4];

      Buffer.BlockCopy(lo_h0, 0, lo_h0_uints, 0, Int128Ex.TypeSize);
      Buffer.BlockCopy(lo_hi, 0, lo_hi_uints, 0, Int128Ex.TypeSize);
      Buffer.BlockCopy(lo_h0, 0, lo_h0_bytes, 0, Int128Ex.TypeSize);
      Buffer.BlockCopy(lo_hi, 0, lo_hi_bytes, 0, Int128Ex.TypeSize);

      var instance = new Int128Ex(lo);
      var bspan = instance.ToSpan();
      if (!bspan.SequenceEqual(lo_h0_bytes))
        throw new ArgumentException(null);

      bspan = instance.ToSpan(false);
      if (!bspan.ToArray().Reverse().SequenceEqual(lo_h0_bytes))
        throw new ArgumentException(null);

      var bytes = instance.ToBytes();
      if (!bytes.SequenceEqual(lo_h0_bytes))
        throw new ArgumentException(null);

      bytes = instance.ToBytes(false);
      if (!bytes.Reverse().SequenceEqual(lo_h0_bytes))
        throw new ArgumentException(null);

      var values = instance.ToValues();
      if (!values.SequenceEqual(lo_h0))
        throw new ArgumentException(null);

      values = instance.ToValues(false);
      if (!values.Reverse().SequenceEqual(lo_h0))
        throw new ArgumentException(null);

      var i128 = Int128Ex.ToInt128Ex(lo_h0_bytes);
      if (i128 != instance)
        throw new ArgumentException(null);

      i128 = Int128Ex.ToInt128Ex(lo_h0_uints);
      if (i128 != instance)
        throw new ArgumentException(null);


      instance = new Int128Ex(hi, lo);
      bspan = instance.ToSpan();
      if (!bspan.SequenceEqual(lo_hi_bytes))
        throw new ArgumentException(null);

      bspan = instance.ToSpan(false);
      if (!bspan.ToArray().Reverse().SequenceEqual(lo_hi_bytes))
        throw new ArgumentException(null);

      bytes = instance.ToBytes();
      if (!bytes.SequenceEqual(lo_hi_bytes))
        throw new ArgumentException(null);

      bytes = instance.ToBytes(false);
      if (!bytes.Reverse().SequenceEqual(lo_hi_bytes))
        throw new ArgumentException(null);

      values = instance.ToValues();
      if (!values.SequenceEqual(lo_hi))
        throw new ArgumentException(null);

      values = instance.ToValues(false);
      if (!values.Reverse().SequenceEqual(lo_hi))
        throw new ArgumentException(null);

      i128 = Int128Ex.ToInt128Ex(lo_hi_bytes);
      if (i128 != instance)
        throw new ArgumentException(null);

      i128 = Int128Ex.ToInt128Ex(lo_hi_uints);
      if (i128 != instance)
        throw new ArgumentException(null);
    }
  }

  private static void TestToString(int counts)
  {

    for (var i = 0; i < counts; i++)
    {
      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var instance = new Int128Ex(lo);
      var binstr = instance.ToString(2);
      var octstr = instance.ToString(8);
      var decstr = instance.ToString(10);
      var hexstr = instance.ToString(16);

      var i128 = Int128Ex.FromDecimalSystem(decstr);
      if (i128 != instance) throw new ArgumentException(null);

      i128 = Int128Ex.FromDualSystem(binstr);
      if (i128 != instance) throw new ArgumentException(null);

      i128 = Int128Ex.FromOctalSystem(octstr);
      if (i128 != instance) throw new ArgumentException(null);

      i128 = Int128Ex.FromHexSystem(hexstr);
      if (i128 != instance) throw new ArgumentException(null);


      instance = new Int128Ex(lo, hi);
      binstr = instance.ToString(2);
      octstr = instance.ToString(8);
      decstr = instance.ToString(10);
      hexstr = instance.ToString(16);

      i128 = Int128Ex.FromDecimalSystem(decstr);
      if (i128 != instance) throw new ArgumentException(null);

      i128 = Int128Ex.FromDualSystem(binstr);
      if (i128 != instance) throw new ArgumentException(null);

      i128 = Int128Ex.FromOctalSystem(octstr);
      if (i128 != instance) throw new ArgumentException(null);

      i128 = Int128Ex.FromHexSystem(hexstr);
      if (i128 != instance) throw new ArgumentException(null);
    }
  }

  private static void TestParse(int counts)
  {
    for (var i = 0; i < counts; i++)
    {
      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var i218 = new Int128(hi, lo);
      var instance = new Int128Ex(hi, lo);
      var b = (byte)instance;
      var usrt = (ushort)instance;
      var ui = (uint)instance;
      var ul = (ulong)instance;

      var sb = (sbyte)instance;
      var srt = (short)instance;
      var ii = (int)instance;
      var ll = (long)instance;

      var sng = (float)instance;
      var dbl = (double)instance;
      var dec = (decimal)instance;

      if (b != Convert.ToByte(instance)) throw new ArgumentException(null);
      if (usrt != Convert.ToUInt16(instance)) throw new ArgumentException(null);
      if (ui != Convert.ToUInt32(instance)) throw new ArgumentException(null);
      if (ul != Convert.ToUInt64(instance)) throw new ArgumentException(null);
      if (sb != Convert.ToSByte(instance)) throw new ArgumentException(null);
      if (srt != Convert.ToInt16(instance)) throw new ArgumentException(null);
      if (ii != Convert.ToInt32(instance)) throw new ArgumentException(null);
      if (ll != Convert.ToInt64(instance)) throw new ArgumentException(null);

      if (sng != Convert.ToSingle(instance)) throw new ArgumentException(null);
      if (dbl != Convert.ToDouble(instance)) throw new ArgumentException(null);
      if (dec != Convert.ToDecimal(instance)) throw new ArgumentException(null);


      //Microsoft Int128-Datatype
      if (b != (byte)(i218)) throw new ArgumentException(null);
      if (usrt != (ushort)(i218)) throw new ArgumentException(null);
      if (ui != (uint)(i218)) throw new ArgumentException(null);
      if (ul != (ulong)(i218)) throw new ArgumentException(null);
      if (sb != (sbyte)(i218)) throw new ArgumentException(null);
      if (srt != (short)(i218)) throw new ArgumentException(null);
      if (ii != (int)(i218)) throw new ArgumentException(null);
      if (ll != (long)(i218)) throw new ArgumentException(null);

      //if (sng != (float)(i218)) throw new ArgumentException(null);
      //if (dbl != (double)(i218)) throw new ArgumentException(null);
      //if (dec != (decimal)(i218)) throw new ArgumentException(null);

    }
  }

  private static void TestParseString(int counts)
  {
    for (var i = 0; i < counts; i++)
    {
      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var instance = new Int128Ex(lo, hi);
      var binstr = instance.ToString(2);
      var octstr = instance.ToString(8);
      var decstr = instance.ToString(10);
      var hexstr = instance.ToString(16);

      var bla = Int128Ex.Parse(binstr, 2);
      if (instance != Int128Ex.Parse(binstr, 2))
        throw new ArgumentException(null);

      if (instance != Int128Ex.Parse(octstr, 8))
        throw new ArgumentException(null);

      if (instance != Int128Ex.Parse(decstr, 10))
        throw new ArgumentException(null);

      if (instance != Int128Ex.Parse(hexstr, 16))
        throw new ArgumentException(null);



      instance = new Int128Ex(lo);
      binstr = instance.ToString(2);
      octstr = instance.ToString(8);
      decstr = instance.ToString(10);
      hexstr = instance.ToString(16);

      if (instance != Int128Ex.Parse(binstr, 2))
        throw new ArgumentException(null);

      if (instance != Int128Ex.Parse(octstr, 8))
        throw new ArgumentException(null);

      if (instance != Int128Ex.Parse(decstr, 10))
        throw new ArgumentException(null);

      if (instance != Int128Ex.Parse(hexstr, 16))
        throw new ArgumentException(null);

      instance = new Int128Ex(0, hi);
      binstr = instance.ToString(2);
      octstr = instance.ToString(8);
      decstr = instance.ToString(10);
      hexstr = instance.ToString(16);

      if (instance != Int128Ex.Parse(binstr, 2))
        throw new ArgumentException(null);

      if (instance != Int128Ex.Parse(octstr, 8))
        throw new ArgumentException(null);

      if (instance != Int128Ex.Parse(decstr, 10))
        throw new ArgumentException(null);

      if (instance != Int128Ex.Parse(hexstr, 16))
        throw new ArgumentException(null);


      var bytes = new byte[Int128Ex.TypeSize];
      Rand.NextBytes(bytes); bytes[0] = 0;

      var lohi = new ulong[2];
      Buffer.BlockCopy(bytes, 0, lohi, 0, Int128Ex.TypeSize);

      instance = new Int128Ex(lohi[1], lohi[0]);
      binstr = instance.ToString(2);
      octstr = instance.ToString(8);
      decstr = instance.ToString(10);
      hexstr = instance.ToString(16);

      if (instance != Int128Ex.Parse(binstr, 2))
        throw new ArgumentException(null);

      if (instance != Int128Ex.Parse(octstr, 8))
        throw new ArgumentException(null);

      if (instance != Int128Ex.Parse(decstr, 10))
        throw new ArgumentException(null);

      if (instance != Int128Ex.Parse(hexstr, 16))
        throw new ArgumentException(null);


      instance = new Int128Ex(lohi[0], lohi[1]);
      binstr = instance.ToString(2);
      octstr = instance.ToString(8);
      decstr = instance.ToString(10);
      hexstr = instance.ToString(16);

      if (instance != Int128Ex.Parse(binstr, 2))
        throw new ArgumentException(null);

      if (instance != Int128Ex.Parse(octstr, 8))
        throw new ArgumentException(null);

      if (instance != Int128Ex.Parse(decstr, 10))
        throw new ArgumentException(null);

      if (instance != Int128Ex.Parse(hexstr, 16))
        throw new ArgumentException(null);

      //bin
      bytes = Enumerable.Range(0, Rand.Next(2, 129)).Select(x => (byte)Rand.Next(0, 2)).ToArray();
      bytes = TrimFirstSetOneZero(bytes);
      var bits = string.Join("", bytes);
      var ui128 = Int128Ex.Parse(bits, 2);
      var strbits = ui128.ToString(2);
      var minlen = Math.Min(bits.Length, strbits.Length);

      if (!strbits.Skip(strbits.Length - minlen).SequenceEqual(bits.Skip(bits.Length - minlen)))
        throw new ArgumentException(null);


      //Oct-Systeme können nicht frei gerandomt werden.
      bytes = Enumerable.Range(0, Rand.Next(2, 129)).Select(x => (byte)Rand.Next(0, 2)).ToArray();
      bytes = TrimFirstSetOneZero(bytes);
      bits = string.Join("", bytes);
      ui128 = Int128Ex.Parse(bits, 2);

      var oct = ui128.ToString(8);
      bits = string.Join("", oct);
      ui128 = Int128Ex.Parse(bits, 8);
      strbits = ui128.ToString(8);
      if (!strbits.SequenceEqual(bits))
        throw new ArgumentException(null);


      //dec
      bytes = Enumerable.Range(0, Rand.Next(2, 38))
        .Select(x => (byte)Rand.Next(0, 10)).ToArray();
      bytes = TrimFirstSetOneZero(bytes);
      bits = string.Join("", bytes);
      ui128 = Int128Ex.Parse(bits, 10);
      strbits = ui128.ToString(10);
      if (bits.Length == strbits.Length)
      {
        if (!strbits.SequenceEqual(bits))
          throw new ArgumentException(null);
      }
      else if (!bits.Skip(1).SequenceEqual(strbits))
        throw new ArgumentException(null);


      //Hex
      bytes = Enumerable.Range(0, Rand.Next(2, 33))
        .Select(x => (byte)Rand.Next(0, 16)).ToArray();

      var hex = "0123456789ABCDEF";
      bytes = TrimFirstSetOneZero(bytes);
      bits = string.Join("", bytes.Select(s => hex[s]));
      ui128 = Int128Ex.Parse(bits, 16);
      strbits = ui128.ToString(16);
      if (bits.Length == strbits.Length)
      {
        if (!strbits.SequenceEqual(bits))
          throw new ArgumentException(null);
      }
      else if (!bits.Skip(1).SequenceEqual(strbits))
        throw new ArgumentException(null);
    }
  }

  private static void TestBitwiseNot(int counts)
  {
    for (var i = 0; i < counts; i++)
    {

      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var ui128 = new Int128(hi, lo);
      var instance = new Int128Ex(hi, lo);

      var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      ui128 += r;
      instance += r;

      var result1 = ~ui128;
      var result2 = ~instance;

      if (!Equal(result2, result1))
        throw new ArgumentException(null);


    }
  }

  private static void TestBitwiseAnd(int counts)
  {

    for (var i = 0; i < counts; i++)
    {

      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var ui128 = new Int128(hi, lo);
      var instance = new Int128Ex(hi, lo);

      var number = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      ui128 += number;
      instance += number;

      var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      ui128 &= r;
      instance &= r;

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);
    }
  }

  private static void TestBitwiseOr(int counts)
  {

    for (var i = 0; i < counts; i++)
    {

      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var ui128 = new Int128(hi, lo);
      var instance = new Int128Ex(hi, lo);

      var number = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      ui128 += number;
      instance += number;

      var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      ui128 |= r;
      instance |= r;

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);
    }
  }

  private static void TestBitwiseXor(int counts)
  {

    for (var i = 0; i < counts; i++)
    {

      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var ui128 = new Int128(hi, lo);
      var instance = new Int128Ex(hi, lo);

      var number = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      ui128 += number;
      instance += number;

      var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      ui128 ^= r;
      instance ^= r;

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);
    }

  }

  private static void TestBitwiseShift(int counts)
  {

    for (var i = 0; i < counts; i++)
    {
      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var ui128 = new Int128(hi, lo);
      var instance = new Int128Ex(hi, lo);

      var number = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      ui128 += number;
      instance += number;

      var l = 1 + (int)double.Truncate(Math.Log10(Math.Pow(2, 128)));
      var r = Rand.Next(0, l);

      ui128 <<= r;
      instance <<= r;

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);


      r = Rand.Next(0, l);

      ui128 >>= r;
      instance >>= r;

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);


      r = Rand.Next(0, l);

      ui128 >>>= r;
      instance >>>= r;

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);
    }
  }

  private static void TestIsZeroOne(int counts)
  {

    for (var i = 0; i < counts; i++)
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
  }

  private static void TestIsMinMax(int counts)
  {

    for (var i = 0; i < counts; i++)
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


      //Checked
      //instance = Int128Ex.MaxValue;
      //checked { instance++; }

      //instance = Int128Ex.MinValue;
      //checked { instance--; }


      //instance = Int128Ex.MaxValue;
      //checked { instance += 1; }

      //instance = Int128Ex.MaxValue;
      //checked { instance = instance + 1; }

      //instance = Int128Ex.MinValue;
      //checked { instance -= 1; }

      //instance = Int128Ex.MinValue;
      //checked { instance = instance- 1; }

    }
  }

  private static void TestEquals(int counts)
  {
    for (var i = 0; i < counts; i++)
    {
      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var ui128 = new Int128(hi, lo);
      var instance1 = new Int128Ex(hi, lo);
      var instance2 = new Int128Ex(hi, lo);

      if (!Equal(instance1, ui128))
        throw new ArgumentException(null);

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
  }

  private static void TestGreatLessThan(int counts)
  {
    for (var i = 0; i < counts; i++)
    {
      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var ui128 = new Int128(hi, lo);
      var instance1 = new Int128Ex(hi, lo);
      var instance2 = new Int128Ex(hi, lo);

      if (!Equal(instance1, ui128))
        throw new ArgumentException(null);

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
  }

  private static void TestIteration(int counts)
  {
    for (var i = 0; i < counts; i++)
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


      //Checked
      //instance = Int128Ex.MaxValue;
      //checked { instance++; }

      //instance = Int128Ex.MinValue;
      //checked { instance--; }


      //instance = Int128Ex.MaxValue;
      //checked { instance += 1; }

      //instance = Int128Ex.MaxValue;
      //checked { instance = instance + 1; }

      //instance = Int128Ex.MinValue;
      //checked { instance -= 1; }

      //instance = Int128Ex.MinValue;
      //checked { instance = instance - 1; }

    }
  }

  private static void TestAddition(int counts)
  {
    for (var i = 0; i < counts; i++)
    {

      var lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var i1281 = new Int128(hi1, lo1);
      var instance1 = new Int128Ex(hi1, lo1);

      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      var ulg = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var uii = (uint)(Rand.NextInt64() * Rand.NextInt64());
      var ushrt = (ushort)(Rand.NextInt64() * Rand.NextInt64());
      var ub = (byte)(Rand.NextInt64() * Rand.NextInt64());

      var lg = Rand.NextInt64() * Rand.NextInt64();
      var ii = (int)(Rand.NextInt64() * Rand.NextInt64());
      var shrt = (short)(Rand.NextInt64() * Rand.NextInt64());
      var sb = (sbyte)(Rand.NextInt64() * Rand.NextInt64());

      i1281 += ulg; instance1 += ulg;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 += uii; instance1 += uii;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 += ushrt; instance1 += ushrt;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 += ub; instance1 += ub;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 += lg; instance1 += lg;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      lg = -lg;
      i1281 += lg; instance1 += lg;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 += ii; instance1 += ii;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      ii = -ii;
      i1281 += ii; instance1 += ii;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 += shrt; instance1 += shrt;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      shrt = (short)-shrt;
      i1281 += shrt; instance1 += shrt;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 += sb; instance1 += sb;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      sb = (sbyte)-sb;
      i1281 += sb; instance1 += sb;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      i1281 = new Int128(hi1, lo1);
      instance1 = new Int128Ex(hi1, lo1);

      var lo2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var i1282 = new Int128(hi2, lo2);
      var instance2 = new Int128Ex(hi2, lo2);

      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      if (!Equal(instance2, i1282))
        throw new ArgumentException(null);

      if (!Equal(instance1 + instance2, i1281 + i1282))
        throw new ArgumentException(null);



      i1281 = Int128.MaxValue - counts;
      instance1 = Int128Ex.MaxValue - counts;
      i1281 = checked(i1281 + i);
      instance1 = checked(instance1 + i);
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 = 0 - counts / 2;
      instance1 = 0 - counts / 2;
      i1281 = checked(i1281 + i);
      instance1 = checked(instance1 + i);
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 = Int128.MinValue + counts;
      instance1 = Int128Ex.MinValue + counts;
      i1281 = checked(i1281 + -i);
      instance1 = checked(instance1 + -i);
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);


      ////Checked
      //lg = -123456;
      //i1281 = Int128.MinValue; instance1 = Int128Ex.MinValue;
      //if (!Equal(instance1, i1281))
      //  throw new ArgumentException(null);
      //i1281 += lg;instance1 += lg;
      //if (!Equal(instance1, i1281))
      //  throw new ArgumentException(null);
      //i1281 -= lg;instance1 -= lg;
      //if (!Equal(instance1, i1281))
      //  throw new ArgumentException(null);

      //lg = -1;
      //i1281 = checked(i1281 + lg);
      //instance1 = checked(instance1 + lg);
      //if (!Equal(instance1, i1281))
      //  throw new ArgumentException(null);

      //lg = -lg;
      //i1281 = Int128.MaxValue; instance1 = Int128Ex.MaxValue;
      //if (!Equal(instance1, i1281))
      //  throw new ArgumentException(null);
      //i1281 = checked(i1281 + lg);
      //instance1 = checked(instance1 + lg);
      //if (!Equal(instance1, i1281))
      //  throw new ArgumentException(null);


      //r = (ulong)Rand.NextInt64();
      //ui128 = checked(ui128 + r);
      //instance = checked(instance + r);

      //ui128 = 0ul; instance = 0ul;
      //ir = -Rand.NextInt64();
      //ui128 = checked(ui128 + (ulong)ir); //overflow
      //instance = checked(instance + (ulong)ir); //overflow

      //ui128 = 0ul; instance = 0ul;
      //r = (ulong)-Rand.NextInt64();
      //ui128 = checked(ui128 + r);
      //instance = checked(instance + r);

      //ui128 = Int128.MaxValue;
      //instance = Int128Ex.MaxValue;
      //r = (ulong)Rand.NextInt64();
      //ui128 = checked(ui128 + r); //overflow
      //instance = checked(instance + r); //overflow

    }
  }

  private static void TestSubtraction(int counts)
  {
    for (var i = 0; i < counts; i++)
    {
      var lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var i1281 = new Int128(hi1, lo1);
      var instance1 = new Int128Ex(hi1, lo1);

      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      var ulg = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var uii = (uint)(Rand.NextInt64() * Rand.NextInt64());
      var ushrt = (ushort)(Rand.NextInt64() * Rand.NextInt64());
      var ub = (byte)(Rand.NextInt64() * Rand.NextInt64());

      var lg = Rand.NextInt64() * Rand.NextInt64();
      var ii = (int)(Rand.NextInt64() * Rand.NextInt64());
      var shrt = (short)(Rand.NextInt64() * Rand.NextInt64());
      var sb = (sbyte)(Rand.NextInt64() * Rand.NextInt64());

      i1281 -= ulg; instance1 -= ulg;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 -= uii; instance1 -= uii;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 -= ushrt; instance1 -= ushrt;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 -= ub; instance1 -= ub;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 -= lg; instance1 -= lg;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      lg = -lg;
      i1281 -= lg; instance1 -= lg;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 -= ii; instance1 -= ii;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      ii = -ii;
      i1281 -= ii; instance1 -= ii;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 -= shrt; instance1 -= shrt;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      shrt = (short)-shrt;
      i1281 -= shrt; instance1 -= shrt;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 -= sb; instance1 -= sb;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      sb = (sbyte)-sb;
      i1281 -= sb; instance1 -= sb;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      i1281 = new Int128(hi1, lo1);
      instance1 = new Int128Ex(hi1, lo1);

      var lo2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var i1282 = new Int128(hi2, lo2);
      var instance2 = new Int128Ex(hi2, lo2);

      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      if (!Equal(instance2, i1282))
        throw new ArgumentException(null);

      if (!Equal(instance1 - instance2, i1281 - i1282))
        throw new ArgumentException(null);

      i1281 = Int128.MaxValue;
      instance1 = Int128Ex.MaxValue;
      i1281 = checked(i1281 - i);
      instance1 = checked(instance1 - i);
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 = counts / 2;
      instance1 = counts / 2;
      i1281 = checked(i1281 - i);
      instance1 = checked(instance1 - i);
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 = Int128.MinValue + counts;
      instance1 = Int128Ex.MinValue + counts;
      i1281 = checked(i1281 - i);
      instance1 = checked(instance1 - i);
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);


      ////checked

      //i1281 = Int128.MinValue;
      //instance1 = Int128Ex.MinValue;
      //i1281 = checked(i1281 - 1);
      //instance1 = checked(instance1 - 1); 

      //i1281 = Int128.MaxValue;
      //instance1 = Int128Ex.MaxValue;
      //i1281 = checked(i1281 - -1);
      //instance1 = checked(instance1 - -1);

    }
  }

  private static void TestMultiplication(int counts)
  {
    for (var i = 0; i < counts; i++)
    {
      var lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var i1281 = new Int128(hi1, lo1);
      var instance1 = new Int128Ex(hi1, lo1);

      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      var ulg = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var uii = (uint)(Rand.NextInt64() * Rand.NextInt64());
      var ushrt = (ushort)(Rand.NextInt64() * Rand.NextInt64());
      var ub = (byte)(Rand.NextInt64() * Rand.NextInt64());

      var lg = Rand.NextInt64() * Rand.NextInt64();
      var ii = (int)(Rand.NextInt64() * Rand.NextInt64());
      var shrt = (short)(Rand.NextInt64() * Rand.NextInt64());
      var sb = (sbyte)(Rand.NextInt64() * Rand.NextInt64());

      i1281 *= ulg; instance1 *= ulg;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 *= uii; instance1 *= uii;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 *= ushrt; instance1 *= ushrt;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 *= ub; instance1 *= ub;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 *= lg; instance1 *= lg;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      lg = -lg;
      i1281 *= lg; instance1 *= lg;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 *= ii; instance1 *= ii;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      ii = -ii;
      i1281 *= ii; instance1 *= ii;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 *= shrt; instance1 *= shrt;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      shrt = (short)-shrt;
      i1281 *= shrt; instance1 *= shrt;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 *= sb; instance1 *= sb;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      sb = (sbyte)-sb;
      i1281 *= sb; instance1 *= sb;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      i1281 = new Int128(hi1, lo1);
      instance1 = new Int128Ex(hi1, lo1);

      var lo2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var i1282 = new Int128(hi2, lo2);
      var instance2 = new Int128Ex(hi2, lo2);

      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      if (!Equal(instance2, i1282))
        throw new ArgumentException(null);

      if (!Equal(instance1 * instance2, i1281 * i1282))
        throw new ArgumentException(null);


      var uimax = (UInt128Ex)Int128Ex.MaxValue;

      i1281 = Int128.MaxValue / 1000;
      instance1 = (Int128Ex)(uimax / 1000);
      i1281 = checked(i1281 * i);
      instance1 = checked(instance1 * i);
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 = counts / 2;
      instance1 = counts / 2;
      i1281 = checked(i1281 * i);
      instance1 = checked(instance1 * i);
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 = Int128.MinValue / 1000;
      instance1 = -(Int128Ex)(uimax / 1000);
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 = checked(i1281 * i);
      instance1 = checked(instance1 * i);
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);


      ////checked

      //i1281 = Int128.MinValue;
      //instance1 = Int128Ex.MinValue;
      //i1281 = checked(i1281 * 2);
      //instance1 = checked(instance1 * 2);

      //i1281 = Int128.MaxValue;
      //instance1 = Int128Ex.MaxValue;
      //i1281 = checked(i1281 * -2);
      //instance1 = checked(instance1 * -2);
    }
  }

  private static void TestDivision(int counts)
  {
    for (var i = 0; i < counts; i++)
    {
      var lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var i1281 = new Int128(hi1, lo1);
      var instance1 = new Int128Ex(hi1, lo1);

      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      var ulg = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var uii = (uint)(Rand.NextInt64() * Rand.NextInt64());
      var ushrt = (ushort)(Rand.NextInt64() * Rand.NextInt64());
      var ub = (byte)(Rand.NextInt64() * Rand.NextInt64());

      var lg = Rand.NextInt64() * Rand.NextInt64();
      var ii = (int)(Rand.NextInt64() * Rand.NextInt64());
      var shrt = (short)(Rand.NextInt64() * Rand.NextInt64());
      var sb = (sbyte)(Rand.NextInt64() * Rand.NextInt64());


      if (ulg == 0) ulg = 1;
      i1281 /= ulg; instance1 /= ulg;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      if (uii == 0) uii = 1;
      i1281 /= uii; instance1 /= uii;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      i1281 = new Int128(hi1, lo1);
      instance1 = new Int128Ex(hi1, lo1);

      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      if (ushrt == 0) ushrt = 1;
      i1281 /= ushrt; instance1 /= ushrt;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      if (ub == 0) ub = 1;
      i1281 /= ub; instance1 /= ub;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      i1281 = new Int128(hi1, lo1);
      instance1 = new Int128Ex(hi1, lo1);

      if (lg == 0) lg = 1;
      i1281 /= lg; instance1 /= lg;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      lg = -lg;
      i1281 /= lg; instance1 /= lg;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      i1281 = new Int128(hi1, lo1);
      instance1 = new Int128Ex(hi1, lo1);

      if (ii == 0) ii = 1;
      i1281 /= ii; instance1 /= ii;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      ii = -ii;
      i1281 /= ii; instance1 /= ii;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      i1281 = new Int128(hi1, lo1);
      instance1 = new Int128Ex(hi1, lo1);

      if (shrt == 0) shrt = 1;
      i1281 /= shrt; instance1 /= shrt;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      shrt = (short)-shrt;
      i1281 /= shrt; instance1 /= shrt;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      if (sb == 0) sb = 1;
      i1281 /= sb; instance1 /= sb;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      sb = (sbyte)-sb;
      i1281 /= sb; instance1 /= sb;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      i1281 = new Int128(hi1, lo1);
      instance1 = new Int128Ex(hi1, lo1);

      var lo2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var i1282 = new Int128(hi2, lo2);
      var instance2 = new Int128Ex(hi2, lo2);

      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      if (!Equal(instance2, i1282))
        throw new ArgumentException(null);

      if (!Equal(instance1 / instance2, i1281 / i1282))
        throw new ArgumentException(null);

      if (i == 0) continue;

      var uimax = (UInt128Ex)Int128Ex.MaxValue;

      i1281 = Int128.MaxValue / 1000;
      instance1 = (Int128Ex)(uimax / 1000);
      i1281 = checked(i1281 / i);
      instance1 = checked(instance1 / i);
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 = counts / 2;
      instance1 = counts / 2;
      i1281 = checked(i1281 / i);
      instance1 = checked(instance1 / i);
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 = Int128.MinValue / 1000;
      instance1 = -(Int128Ex)(uimax / 1000);
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 = checked(i1281 / i);
      instance1 = checked(instance1 / i);
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

    }
  }

  private static void TestModulo(int counts)
  {
    for (var i = 0; i < counts; i++)
    {
      var lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var i1281 = new Int128(hi1, lo1);
      var instance1 = new Int128Ex(hi1, lo1);

      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      var ulg = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var uii = (uint)(Rand.NextInt64() * Rand.NextInt64());
      var ushrt = (ushort)(Rand.NextInt64() * Rand.NextInt64());
      var ub = (byte)(Rand.NextInt64() * Rand.NextInt64());

      var lg = Rand.NextInt64() * Rand.NextInt64();
      var ii = (int)(Rand.NextInt64() * Rand.NextInt64());
      var shrt = (short)(Rand.NextInt64() * Rand.NextInt64());
      var sb = (sbyte)(Rand.NextInt64() * Rand.NextInt64());


      var probe1 = -123456789 % -987;
      var probe2 = 123456789 % -987;
      var probe3 = -123456789 % 987;
      var probe4 = 123456789 % 987;

      if (ulg == 0) ulg = 1;
      i1281 %= ulg; instance1 %= ulg;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      if (uii == 0) uii = 1;
      i1281 %= uii; instance1 %= uii;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      i1281 = new Int128(hi1, lo1);
      instance1 = new Int128Ex(hi1, lo1);

      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      if (ushrt == 0) ushrt = 1;
      i1281 %= ushrt; instance1 %= ushrt;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      if (ub == 0) ub = 1;
      i1281 %= ub; instance1 %= ub;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      i1281 = new Int128(hi1, lo1);
      instance1 = new Int128Ex(hi1, lo1);

      if (lg == 0) lg = 1;
      i1281 %= lg; instance1 %= lg;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      lg = -lg;
      i1281 %= lg; instance1 %= lg;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      i1281 = new Int128(hi1, lo1);
      instance1 = new Int128Ex(hi1, lo1);

      if (ii == 0) ii = 1;
      i1281 %= ii; instance1 %= ii;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      ii = -ii;
      i1281 %= ii; instance1 %= ii;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      i1281 = new Int128(hi1, lo1);
      instance1 = new Int128Ex(hi1, lo1);

      if (shrt == 0) shrt = 1;
      i1281 %= shrt; instance1 %= shrt;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      shrt = (short)-shrt;
      i1281 %= shrt; instance1 %= shrt;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      if (sb == 0) sb = 1;
      i1281 %= sb; instance1 %= sb;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      sb = (sbyte)-sb;
      i1281 %= sb; instance1 %= sb;
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      lo1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      hi1 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      i1281 = new Int128(hi1, lo1);
      instance1 = new Int128Ex(hi1, lo1);

      var lo2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi2 = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var i1282 = new Int128(hi2, lo2);
      var instance2 = new Int128Ex(hi2, lo2);

      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      if (!Equal(instance2, i1282))
        throw new ArgumentException(null);

      if (!Equal(instance1 % instance2, i1281 % i1282))
        throw new ArgumentException(null);

      if (i == 0) continue;

      var uimax = (UInt128Ex)Int128Ex.MaxValue;

      i1281 = Int128.MaxValue / 1000;
      instance1 = (Int128Ex)(uimax / 1000);
      i1281 = checked(i1281 % i);
      instance1 = checked(instance1 % i);
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);


      //Bei Modulo gibt es eigentlich kein checked
      i1281 = counts / 2;
      instance1 = counts / 2;
      i1281 = checked(i1281 % i);
      instance1 = checked(instance1 % i);
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 = Int128.MinValue / 1000;
      instance1 = -(Int128Ex)(uimax / 1000);
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);

      i1281 = checked(i1281 % i);
      instance1 = checked(instance1 % i);
      if (!Equal(instance1, i1281))
        throw new ArgumentException(null);
    }
  }

  private static void TestPow(int counts)
  {
    for (var i = 0; i < counts; i++)
    {
      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var bi = ToI128((BigInteger)lo | ((BigInteger)hi) << 64);
      var instance = new Int128Ex(hi, lo);

      if (!Equal(instance, bi))
        throw new ArgumentException(null);

      var e = Rand.Next(0, 15);
      var sign = bi.Sign;
      bi = ToI128(BigInteger.Pow(BigInteger.Abs(bi), e));
      if (bi.Sign != sign) bi = -bi;
      instance = Int128Ex.Pow(instance, e);

      if (!Equal(instance, bi))
        throw new ArgumentException(null);

      e = Rand.Next(0, 128);
      var p2 = Int128Ex.PowerOfTwo(e, out var overflow);
      if (overflow) throw new ArgumentException(null);

      var bip2 = ToI128(BigInteger.One << e);

      if (!Equal(p2, bip2))
        throw new ArgumentException(null);

      if (!Int128Ex.IsPowerTwo(p2))
        throw new ArgumentException(null);

      e = Rand.Next(0, 39);
      var p10 = Int128Ex.PowerOfTwo(e, out overflow);
      if (overflow) throw new ArgumentException(null);

      var bip10 = BigInteger.One << e;

      if (!Equal(p10, bip10))
        throw new ArgumentException(null);
    }
  }

  private static void TestNegate(int counts)
  {
    for (var i = 0; i < counts; i++)
    {
      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var ui128 = new Int128(hi, lo);
      var instance = new Int128Ex(hi, lo);

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);

      ui128 = -ui128; instance = -instance;

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);

    }
  }

  private static bool Equal(Int128Ex left, Int128 right)
  {
    return left.ToString().SequenceEqual(right.ToString());
  }

  private static bool Equal(Int128Ex left, BigInteger right)
  {
    return left.ToString().SequenceEqual(right.ToString());
  }

  private static BigInteger ToI128(BigInteger bi)
  {
    var b = bi % (BigInteger.One << 128);
    b = (b + (BigInteger.One << 128)) % (BigInteger.One << 128);

    if (b < (BigInteger.One << 127)) return b;

    var c = ~b + 1;


    var r = (b - (BigInteger.One << 127));
    var res = r - (BigInteger.One << 127);
    return res;
  }


  private static string ToBinaryString(BigInteger bigint)
  {
    //https://stackoverflow.com/a/15447131
    var bytes = bigint.ToByteArray();
    var idx = bytes.Length - 1;

    // Create a StringBuilder having appropriate capacity.
    var base2 = new StringBuilder(bytes.Length * 8);

    // Convert first byte to binary.
    var binary = Convert.ToString(bytes[idx], 2);

    // Ensure leading zero exists if value is positive.
    if (binary[0] != '0' && bigint.Sign == 1)
    {
      base2.Append('0');
    }

    // Append binary string to StringBuilder.
    base2.Append(binary);

    // Convert remaining bytes adding leading zeros.
    for (idx--; idx >= 0; idx--)
    {
      base2.Append(Convert.ToString(bytes[idx], 2).PadLeft(8, '0'));
    }

    return base2.ToString();
  }

  private static string ToHexadecimalString(BigInteger bigint)
  {
    //https://stackoverflow.com/a/15447131
    return bigint.ToString("X");
  }



  private static string ToOctalString(BigInteger bigint)
  {
    //https://stackoverflow.com/a/15447131
    var bytes = bigint.ToByteArray();
    var idx = bytes.Length - 1;

    // Create a StringBuilder having appropriate capacity.
    var base8 = new StringBuilder(((bytes.Length / 3) + 1) * 8);

    // Calculate how many bytes are extra when byte array is split
    // into three-byte (24-bit) chunks.
    var extra = bytes.Length % 3;

    // If no bytes are extra, use three bytes for first chunk.
    if (extra == 0)
    {
      extra = 3;
    }

    // Convert first chunk (24-bits) to integer value.
    int int24 = 0;
    for (; extra != 0; extra--)
    {
      int24 <<= 8;
      int24 += bytes[idx--];
    }

    // Convert 24-bit integer to octal without adding leading zeros.
    var octal = Convert.ToString(int24, 8);

    // Ensure leading zero exists if value is positive.
    if (octal[0] != '0' && bigint.Sign == 1)
    {
      base8.Append('0');
    }

    // Append first converted chunk to StringBuilder.
    base8.Append(octal);

    // Convert remaining 24-bit chunks, adding leading zeros.
    for (; idx >= 0; idx -= 3)
    {
      int24 = (bytes[idx] << 16) + (bytes[idx - 1] << 8) + bytes[idx - 2];
      base8.Append(Convert.ToString(int24, 8).PadLeft(8, '0'));
    }

    return base8.ToString();
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



  private static Int128 Mul(Int128 left, Int128 right)
  {
    Int128 upper = BigMul127(left, right, out Int128 lower);

    if (((upper != 0) || (lower < 0)) && ((~upper != 0) || (lower >= 0)))
    {
      // The upper bits can safely be either Zero or AllBitsSet
      // where the former represents a positive value and the
      // latter a negative value.
      //
      // However, when the upper bits are Zero, we also need to
      // confirm the lower bits are positive, otherwise we have
      // a positive value greater than MaxValue and should throw
      //
      // Likewise, when the upper bits are AllBitsSet, we also
      // need to confirm the lower bits are negative, otherwise
      // we have a large negative value less than MinValue and
      // should throw.

      throw new OverflowException();
    }

    return lower;
  }

  private static Int128 BigMul127(Int128 left, Int128 right, out Int128 lower)
  {
    UInt128 upper = BigMul128((UInt128)(left), (UInt128)(right), out UInt128 ulower);
    lower = (Int128)(ulower);
    return (Int128)(upper) - ((left >> 127) & right) - ((right >> 127) & left);
  }

  private static UInt128 BigMul128(UInt128 left, UInt128 right, out UInt128 lower)
  {
    // Adaptation of algorithm for multiplication
    // of 32-bit unsigned integers described
    // in Hacker's Delight by Henry S. Warren, Jr. (ISBN 0-201-91465-4), Chapter 8
    // Basically, it's an optimized version of FOIL method applied to
    // low and high qwords of each operand

    UInt128 al = (ulong)left;
    UInt128 ah = (ulong)(left >> 64);

    UInt128 bl = (ulong)right;
    UInt128 bh = (ulong)(right >> 64);

    UInt128 mull = al * bl;
    UInt128 t = ah * bl + (mull >> 64);
    UInt128 tl = al * bh + (ulong)t;

    lower = new UInt128((ulong)tl, (ulong)mull);
    return ah * bh + (t >> 64) + (tl >> 64);
  }
}



