

using michele.natale.Numbers;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace TestUIntX;


using static Randomholder;


public class TestFullUnitTestUInt128Ex
{
  public static void Start()
  {
    //TestNsc();

    TestSizeOf();
    TestInstance();
    TestConverts();

    var counts = 1000;
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

  private unsafe static void TestSizeOf()
  {
    var size_of = sizeof(UInt128Ex);

    if (size_of != UInt128Ex.TypeSize)
      throw new ArgumentException(null);

    var type_size = Marshal.SizeOf<UInt128Ex>();

    if (type_size != UInt128Ex.TypeSize)
      throw new ArgumentException(null);
  }

  private static void TestInstance()
  {
    var instance = new UInt128Ex();
    var str = instance.ToString();


    //unsigned

    byte ui8 = 5;
    instance = new UInt128Ex(ui8);

    ushort ui16 = 5;
    instance = new UInt128Ex(ui16);

    uint ui32 = 5;
    instance = new UInt128Ex(ui32);

    ulong ui64 = 5;
    instance = new UInt128Ex(ui64);


    //signed

    sbyte i8 = 5;
    instance = new UInt128Ex(i8);
    if (!Equal(instance, (UInt128)i8))
      throw new ArgumentException(null);
    instance = new UInt128Ex(-i8);
    if (!Equal(instance, (UInt128)(-i8)))
      throw new ArgumentException(null);

    short i16 = 5;
    instance = new UInt128Ex(i16);
    if (!Equal(instance, (UInt128)i16))
      throw new ArgumentException(null);
    instance = new UInt128Ex(-i16);
    if (!Equal(instance, (UInt128)(-i16)))
      throw new ArgumentException(null);

    int i32 = 5;
    instance = new UInt128Ex(i32);
    if (!Equal(instance, (UInt128)i32))
      throw new ArgumentException(null);
    instance = new UInt128Ex(-i32);
    if (!Equal(instance, (UInt128)(-i32)))
      throw new ArgumentException(null);

    long i64 = 5;
    instance = new UInt128Ex(i64);
    if (!Equal(instance, (UInt128)i64))
      throw new ArgumentException(null);
    instance = new UInt128Ex(-i64);
    if (!Equal(instance, (UInt128)(-i64)))
      throw new ArgumentException(null);

    var cnt = 100;
    for (var i = 0; i < cnt; i++)
    {
      var lo = Rand.NextInt64();
      var hi = Rand.NextInt64();
      instance = new UInt128Ex(lo);
      if (!Equal(instance, (UInt128)lo))
        throw new ArgumentException(null);
      instance = new UInt128Ex(-lo);
      if (!Equal(instance, (UInt128)(-lo)))
        throw new ArgumentException(null);

      instance = new UInt128Ex((ulong)hi, (ulong)lo);
      if (!Equal(instance, new UInt128((ulong)hi, (ulong)lo)))
        throw new ArgumentException(null);
      instance = new UInt128Ex((ulong)-hi, (ulong)-lo);
      if (!Equal(instance, new UInt128((ulong)-hi, (ulong)-lo)))
        throw new ArgumentException(null);
    }
  }

  private static void TestConverts()
  {

    //unchecked

    byte ui8 = 5;
    var instance = (UInt128Ex)ui8;
    if (!Equal(instance, (UInt128)ui8))
      throw new ArgumentException(null);

    ushort ui16 = 5;
    instance = (UInt128Ex)(ui16);
    if (!Equal(instance, (UInt128)ui16))
      throw new ArgumentException(null);

    uint ui32 = 5;
    instance = (UInt128Ex)(ui32);
    if (!Equal(instance, (UInt128)ui32))
      throw new ArgumentException(null);

    ulong ui64 = 5;
    instance = (UInt128Ex)(ui64);
    if (!Equal(instance, (UInt128)ui64))
      throw new ArgumentException(null);

    sbyte i8 = 5;
    instance = (UInt128Ex)(i8);
    if (!Equal(instance, (UInt128)i8))
      throw new ArgumentException(null);
    i8 = (sbyte)-i8;
    instance = (UInt128Ex)(i8);
    if (!Equal(instance, (UInt128)i8))
      throw new ArgumentException(null);

    short i16 = 5;
    instance = (UInt128Ex)(i16);
    if (!Equal(instance, (UInt128)i16))
      throw new ArgumentException(null);
    i16 = (short)-i16;
    instance = (UInt128Ex)(i16);
    if (!Equal(instance, (UInt128)i16))
      throw new ArgumentException(null);

    int i32 = 5;
    instance = (UInt128Ex)(i32);
    if (!Equal(instance, (UInt128)i32))
      throw new ArgumentException(null);
    i32 = -i32;
    instance = (UInt128Ex)(i32);
    if (!Equal(instance, (UInt128)i32))
      throw new ArgumentException(null);

    long i64 = 5;
    instance = (UInt128Ex)i64;
    if (!Equal(instance, (UInt128)i64))
      throw new ArgumentException(null);
    i64 = -i64;
    instance = (UInt128Ex)i64;
    if (!Equal(instance, (UInt128)i64))
      throw new ArgumentException(null);


    float flt = 5f;
    instance = (UInt128Ex)flt;
    if (!Equal(instance, (UInt128)flt))
      throw new ArgumentException(null);
    flt = -flt;
    instance = (UInt128Ex)flt;

    //UInt128 gibt hier ein 0 zurück.
    //Meiner Ansicht nach ist das falsch, 
    //es muss der gleiche Wert ergeben wie -5
    if (!Equal(instance, (UInt128)i64))
      throw new ArgumentException(null);

    double dbl = 5.0;
    instance = (UInt128Ex)(dbl);
    if (!Equal(instance, (UInt128)dbl))
      throw new ArgumentException(null);
    dbl = -dbl;
    instance = (UInt128Ex)(dbl);
    if (!Equal(instance, (UInt128)i64))
      throw new ArgumentException(null);

    decimal dec = 5m;
    instance = (UInt128Ex)(dec);
    if (!Equal(instance, (UInt128)dec))
      throw new ArgumentException(null);
    dec = -dec;
    instance = (UInt128Ex)(dec);
    if (!Equal(instance, (UInt128)i64))
      throw new ArgumentException(null);



    //checked

    ui8 = 5;
    instance = checked((UInt128Ex)ui8);
    if (!Equal(instance, checked((UInt128)ui8)))
      throw new ArgumentException(null);

    ui16 = 5;
    instance = checked((UInt128Ex)ui16);
    if (!Equal(instance, checked((UInt128)ui16)))
      throw new ArgumentException(null);

    ui32 = 5;
    instance = checked((UInt128Ex)ui32);
    if (!Equal(instance, checked((UInt128)ui32)))
      throw new ArgumentException(null);

    ui64 = 5;
    instance = checked((UInt128Ex)ui64);
    if (!Equal(instance, checked((UInt128)ui64)))
      throw new ArgumentException(null);

    //i8 = 5;
    //instance = checked((UInt128Ex)(i8));
    //if (!Equal(instance, checked((UInt128)i8)))
    //  throw new ArgumentException(null);
    //i8 = (sbyte)-i8;
    //instance = checked((UInt128Ex)(i8));
    //if (!Equal(instance, checked((UInt128)(i8))))
    //  throw new ArgumentException(null);

    //i16 = 5;
    //instance = checked((UInt128Ex)(i16));
    //if (!Equal(instance, checked((UInt128)i16)))
    //  throw new ArgumentException(null);
    //i16 = (short)-i16;
    //instance = checked((UInt128Ex)(i16));
    //if (!Equal(instance, checked((UInt128)(i16))))
    //  throw new ArgumentException(null);

    //i32 = 5;
    //instance = checked((UInt128Ex)(i32));
    //if (!Equal(instance, checked((UInt128)i32)))
    //  throw new ArgumentException(null);
    //i32 = -i32;
    //instance = checked((UInt128Ex)(-i32));
    //if (!Equal(instance, checked((UInt128)(i32))))
    //  throw new ArgumentException(null);

    //i64 = 5;
    //instance = checked((UInt128Ex)(i64));
    //if (!Equal(instance, checked((UInt128)i64)))
    //  throw new ArgumentException(null);
    //i64 = -i64;
    //instance = checked((UInt128Ex)(-i64));
    //if (!Equal(instance, checked((UInt128)(i64))))
    //  throw new ArgumentException(null);


    flt = 5f;
    instance = checked((UInt128Ex)flt);
    if (!Equal(instance, checked((UInt128)flt)))
      throw new ArgumentException(null);

    //flt= -flt;
    //instance = checked((UInt128Ex)(flt));

    ////UInt128 gibt hier ein 0 zurück.
    ////Meiner Ansicht nach ist das falsch, 
    ////es muss der gleiche Wert ergeben wie -5
    //if (!Equal(instance, checked((UInt128)(i64))))
    //  throw new ArgumentException(null);

    //Bemerkung: float kann nicht grösser werden als 2^128

    dec = 5m;
    instance = checked((UInt128Ex)dec);
    if (!Equal(instance, checked((UInt128)dec)))
      throw new ArgumentException(null);
    //dec = -dec;
    //instance = checked((UInt128Ex)(dec));
    //if (!Equal(instance, checked((UInt128)(i64))))
    //  throw new ArgumentException(null);

    //Bemerkung: decimal kann nicht grösser werden als 2^128


    dbl = 5.0;
    instance = checked((UInt128Ex)dbl);
    if (!Equal(instance, checked((UInt128)dbl)))
      throw new ArgumentException(null);

    //dbl = -dbl;
    //instance = checked((UInt128Ex)(dbl));
    //if (!Equal(instance, checked((UInt128)(i64))))
    //  throw new ArgumentException(null);

    //dbl = 340282366920938463463374607431768211456.0;
    //instance = checked((UInt128Ex)(dbl));
    //if (!Equal(instance, checked((UInt128)(dbl))))
    //  throw new ArgumentException(null);


    var cnt = 100;
    for (var i = 0; i < cnt; i++)
    {
      dbl = Rand.NextDouble() * 340282366920938463463374607431768211456.0;
      ui8 = (byte)dbl;
      instance = (UInt128Ex)(ui8);
      if (!Equal(instance, (UInt128)ui8))
        throw new ArgumentException(null);

      ui16 = (ushort)dbl;
      instance = (UInt128Ex)(ui16);
      if (!Equal(instance, (UInt128)ui16))
        throw new ArgumentException(null);

      ui32 = (uint)dbl;
      instance = (UInt128Ex)(ui32);
      if (!Equal(instance, (UInt128)ui32))
        throw new ArgumentException(null);

      ui64 = (ulong)dbl;
      instance = (UInt128Ex)(ui64);
      if (!Equal(instance, (UInt128)ui64))
        throw new ArgumentException(null);

      i8 = (sbyte)dbl;
      instance = (UInt128Ex)(i8);
      if (!Equal(instance, (UInt128)i8))
        throw new ArgumentException(null);
      i8 = (sbyte)-i8;
      instance = (UInt128Ex)(i8);
      if (!Equal(instance, (UInt128)i8))
        throw new ArgumentException(null);

      i16 = (short)dbl;
      instance = (UInt128Ex)(i16);
      if (!Equal(instance, (UInt128)i16))
        throw new ArgumentException(null);
      i16 = (short)-i16;
      instance = (UInt128Ex)(i16);
      if (!Equal(instance, (UInt128)i16))
        throw new ArgumentException(null);

      i32 = (int)dbl;
      instance = (UInt128Ex)(i32);
      if (!Equal(instance, (UInt128)i32))
        throw new ArgumentException(null);
      i32 = -i32;
      instance = (UInt128Ex)(i32);
      if (!Equal(instance, (UInt128)i32))
        throw new ArgumentException(null);

      i64 = (long)dbl;
      instance = (UInt128Ex)(i64);
      if (!Equal(instance, (UInt128)i64))
        throw new ArgumentException(null);
      i64 = -i64;
      instance = (UInt128Ex)(i64);
      if (!Equal(instance, (UInt128)i64))
        throw new ArgumentException(null);

      var bi = new BigInteger(dbl);
      flt = (float)(bi % (1 + (BigInteger)float.MaxValue));
      instance = (UInt128Ex)(flt);
      if (!Equal(instance, (UInt128)flt))
        throw new ArgumentException(null);
      flt = -flt;
      instance = (UInt128Ex)flt;

      //UInt128 gibt hier ein 0 zurück.
      //Meiner Ansicht nach ist das falsch, 
      //es muss der gleiche Wert ergeben wie -5
      //if (!Equal(instance, (UInt128)(flt)))
      //  throw new ArgumentException(null); 

      var dbi = new BigInteger(dbl);
      var dblli2 = dbi % (BigInteger.One << 128);
      var dblli3 = (-dbi % (BigInteger.One << 128)) + (BigInteger.One << 128);

      instance = (UInt128Ex)dbl;
      if (!Equal(instance, dblli2))
        throw new ArgumentException(null);
      dbl = -dbl;
      instance = (UInt128Ex)dbl;
      if (!Equal(instance, dblli3))
        throw new ArgumentException(null);

      var decbi1 = new BigInteger(dbl) % (BigInteger.One << 96);
      var decbi2 = new BigInteger(-dbl) % (BigInteger.One << 96);

      dec = (decimal)(decbi1);
      instance = (UInt128Ex)dec;
      if (!Equal(instance, decbi1 + (BigInteger.One << 128)))
        throw new ArgumentException(null);
      dec = -dec;
      instance = (UInt128Ex)dec;
      if (!Equal(instance, decbi2))
        throw new ArgumentException(null);



      //checked
      //Sobald negative oder zu grosse Zahlen im Spiel sind, wird eine
      //Exception geworfen.

      ui8 = (byte)dbl;
      instance = checked((UInt128Ex)ui8);
      if (!Equal(instance, checked((UInt128)ui8)))
        throw new ArgumentException(null);

      ui16 = (ushort)dbl;
      instance = checked((UInt128Ex)ui16);
      if (!Equal(instance, checked((UInt128)ui16)))
        throw new ArgumentException(null);

      ui32 = (uint)dbl;
      instance = checked((UInt128Ex)ui32);
      if (!Equal(instance, checked((UInt128)ui32)))
        throw new ArgumentException(null);

      ui64 = (ulong)dbl;
      instance = checked((UInt128Ex)ui64);
      if (!Equal(instance, checked((UInt128)ui64)))
        throw new ArgumentException(null);

      //flt = (float)dbl;
      //var f = (BigInteger)float.MaxValue;
      //instance = checked((UInt128Ex)(flt));
      ////if (!Equal(instance, checked((UInt128)(flt))))
      ////  throw new ArgumentException(null); 

      ////Bemerkung: float kann nicht grösser werden als 2^128

      //decbi1 = new BigInteger(dbl) % (BigInteger.One << 96);
      //decbi2 = new BigInteger(-dbl) % (BigInteger.One << 96);
      //dec = (decimal)(decbi1);
      //instance = checked((UInt128Ex)(dec));
      //if (!Equal(instance, checked((UInt128)dec)))
      //  throw new ArgumentException(null);

      ////Bemerkung: decimal kann nicht grösser werden als 2^128

      //dbl %= 340282366920938463463374607431768211456.0; 
      //instance = checked((UInt128Ex)(dbl));
      //if (!Equal(instance, checked((UInt128)dbl)))
      //  throw new ArgumentException(null);

      //dbl = flt;
      //instance = checked((UInt128Ex)(dbl));
      //if (!Equal(instance, checked((UInt128)dbl)))
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

      var lo_h0_bytes = new byte[UInt128Ex.TypeSize];
      var lo_hi_bytes = new byte[UInt128Ex.TypeSize];
      var lo_h0_uints = new uint[UInt128Ex.TypeSize / 4];
      var lo_hi_uints = new uint[UInt128Ex.TypeSize / 4];

      Buffer.BlockCopy(lo_h0, 0, lo_h0_uints, 0, UInt128Ex.TypeSize);
      Buffer.BlockCopy(lo_hi, 0, lo_hi_uints, 0, UInt128Ex.TypeSize);
      Buffer.BlockCopy(lo_h0, 0, lo_h0_bytes, 0, UInt128Ex.TypeSize);
      Buffer.BlockCopy(lo_hi, 0, lo_hi_bytes, 0, UInt128Ex.TypeSize);

      var instance = new UInt128Ex(lo);
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

      var ui128 = UInt128Ex.ToUInt128Ex(lo_h0_bytes);
      if (ui128 != instance)
        throw new ArgumentException(null);

      ui128 = UInt128Ex.ToUInt128Ex(lo_h0_uints);
      if (ui128 != instance)
        throw new ArgumentException(null);


      instance = new UInt128Ex(hi, lo);
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

      ui128 = UInt128Ex.ToUInt128Ex(lo_hi_bytes);
      if (ui128 != instance)
        throw new ArgumentException(null);

      ui128 = UInt128Ex.ToUInt128Ex(lo_hi_uints);
      if (ui128 != instance)
        throw new ArgumentException(null);
    }
  }

  private static void TestToString(int counts)
  {
    for (var i = 0; i < counts; i++)
    {
      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var instance = new UInt128Ex(lo, hi);
      var binstr = instance.ToString(2);
      var octstr = instance.ToString(8);
      var decstr = instance.ToString(10);
      var hexstr = instance.ToString(16);

      var number = BigInteger.Parse(decstr);
      var bidec = number.ToString();
      if (!bidec.SequenceEqual(decstr))
        throw new ArgumentException(null);

      var bihex = number.ToString("X");
      if (bihex.Length == hexstr.Length)
      {
        if (!bihex.SequenceEqual(hexstr))
          throw new ArgumentException(null);
      }
      else if (!bihex.SequenceEqual("0" + hexstr))
        throw new ArgumentException(null);

      var bibin = ToBinaryString(number);
      if (!binstr.SequenceEqual(bibin))
        throw new ArgumentException(null);

      var bioct = ToOctalString(number);
      if (bioct.Length == octstr.Length)
      {
        if (!bioct.SequenceEqual(octstr))
          throw new ArgumentException(null);
      }
      else if (!bioct.SequenceEqual("0" + octstr))
        throw new ArgumentException(null);
    }

    for (var i = 0; i < counts; i++)
    {
      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var instance = new UInt128Ex(lo, hi);
      var binstr = instance.ToString(2);
      var octstr = instance.ToString(8);
      var decstr = instance.ToString(10);
      var hexstr = instance.ToString(16);

      var ui128 = UInt128Ex.FromDualSystem(binstr);
      if (instance != ui128)
        throw new ArgumentException(null);

      ui128 = UInt128Ex.FromOctalSystem(octstr);
      if (instance != ui128)
        throw new ArgumentException(null);

      ui128 = UInt128Ex.FromDecimalSystem(decstr);
      if (instance != ui128)
        throw new ArgumentException(null);

      ui128 = UInt128Ex.FromHexSystem(hexstr);
      if (instance != ui128)
        throw new ArgumentException(null);
    }

  }

  private static void TestParse(int counts)
  {
    for (var i = 0; i < counts; i++)
    {
      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var ui218 = new UInt128(hi, lo);
      var instance = new UInt128Ex(hi, lo);
      var b = (byte)instance;
      var usrt = (ushort)instance;
      var ui = (uint)instance;
      var ul = (ulong)instance;

      var sb = (sbyte)instance;
      var srt = (short)instance;
      var ii = (int)instance;
      var ll = (long)instance;

      if (b != Convert.ToByte(instance)) throw new ArgumentException(null);
      if (usrt != Convert.ToUInt16(instance)) throw new ArgumentException(null);
      if (ui != Convert.ToUInt32(instance)) throw new ArgumentException(null);
      if (ul != Convert.ToUInt64(instance)) throw new ArgumentException(null);
      if (sb != Convert.ToSByte(instance)) throw new ArgumentException(null);
      if (srt != Convert.ToInt16(instance)) throw new ArgumentException(null);
      if (ii != Convert.ToInt32(instance)) throw new ArgumentException(null);
      if (ll != Convert.ToInt64(instance)) throw new ArgumentException(null);


      if (b != (byte)(ui218)) throw new ArgumentException(null);
      if (usrt != (ushort)(ui218)) throw new ArgumentException(null);
      if (ui != (uint)(ui218)) throw new ArgumentException(null);
      if (ul != (ulong)(ui218)) throw new ArgumentException(null);
      if (sb != (sbyte)(ui218)) throw new ArgumentException(null);
      if (srt != (short)(ui218)) throw new ArgumentException(null);
      if (ii != (int)(ui218)) throw new ArgumentException(null);
      if (ll != (long)(ui218)) throw new ArgumentException(null);
    }
  }

  private static void TestParseString(int counts)
  {
    for (var i = 0; i < counts; i++)
    {
      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var instance = new UInt128Ex(lo, hi);
      var binstr = instance.ToString(2);
      var octstr = instance.ToString(8);
      var decstr = instance.ToString(10);
      var hexstr = instance.ToString(16);

      var bla = UInt128Ex.Parse(binstr, 2);
      if (instance != UInt128Ex.Parse(binstr, 2))
        throw new ArgumentException(null);

      if (instance != UInt128Ex.Parse(octstr, 8))
        throw new ArgumentException(null);

      if (instance != UInt128Ex.Parse(decstr, 10))
        throw new ArgumentException(null);

      if (instance != UInt128Ex.Parse(hexstr, 16))
        throw new ArgumentException(null);



      instance = new UInt128Ex(lo);
      binstr = instance.ToString(2);
      octstr = instance.ToString(8);
      decstr = instance.ToString(10);
      hexstr = instance.ToString(16);

      if (instance != UInt128Ex.Parse(binstr, 2))
        throw new ArgumentException(null);

      if (instance != UInt128Ex.Parse(octstr, 8))
        throw new ArgumentException(null);

      if (instance != UInt128Ex.Parse(decstr, 10))
        throw new ArgumentException(null);

      if (instance != UInt128Ex.Parse(hexstr, 16))
        throw new ArgumentException(null);

      instance = new UInt128Ex(0, hi);
      binstr = instance.ToString(2);
      octstr = instance.ToString(8);
      decstr = instance.ToString(10);
      hexstr = instance.ToString(16);

      if (instance != UInt128Ex.Parse(binstr, 2))
        throw new ArgumentException(null);

      if (instance != UInt128Ex.Parse(octstr, 8))
        throw new ArgumentException(null);

      if (instance != UInt128Ex.Parse(decstr, 10))
        throw new ArgumentException(null);

      if (instance != UInt128Ex.Parse(hexstr, 16))
        throw new ArgumentException(null);


      var bytes = new byte[UInt128Ex.TypeSize];
      Rand.NextBytes(bytes); bytes[0] = 0;

      var lohi = new ulong[2];
      Buffer.BlockCopy(bytes, 0, lohi, 0, UInt128Ex.TypeSize);

      instance = new UInt128Ex(lohi[1], lohi[0]);
      binstr = instance.ToString(2);
      octstr = instance.ToString(8);
      decstr = instance.ToString(10);
      hexstr = instance.ToString(16);

      if (instance != UInt128Ex.Parse(binstr, 2))
        throw new ArgumentException(null);

      if (instance != UInt128Ex.Parse(octstr, 8))
        throw new ArgumentException(null);

      if (instance != UInt128Ex.Parse(decstr, 10))
        throw new ArgumentException(null);

      if (instance != UInt128Ex.Parse(hexstr, 16))
        throw new ArgumentException(null);


      instance = new UInt128Ex(lohi[0], lohi[1]);
      binstr = instance.ToString(2);
      octstr = instance.ToString(8);
      decstr = instance.ToString(10);
      hexstr = instance.ToString(16);

      if (instance != UInt128Ex.Parse(binstr, 2))
        throw new ArgumentException(null);

      if (instance != UInt128Ex.Parse(octstr, 8))
        throw new ArgumentException(null);

      if (instance != UInt128Ex.Parse(decstr, 10))
        throw new ArgumentException(null);

      if (instance != UInt128Ex.Parse(hexstr, 16))
        throw new ArgumentException(null);

      //bin
      bytes = Enumerable.Range(0, Rand.Next(2, 129)).Select(x => (byte)Rand.Next(0, 2)).ToArray();
      bytes = TrimFirstSetOneZero(bytes);
      var bits = string.Join("", bytes);
      var ui128 = UInt128Ex.Parse(bits, 2);
      var strbits = ui128.ToString(2);
      if (!strbits.SequenceEqual(bits))
        throw new ArgumentException(null);


      //Oct-Systeme können nicht frei gerandomt werden.
      bytes = Enumerable.Range(0, Rand.Next(2, 129)).Select(x => (byte)Rand.Next(0, 2)).ToArray();
      bytes = TrimFirstSetOneZero(bytes);
      bits = string.Join("", bytes);
      ui128 = UInt128Ex.Parse(bits, 2);

      var oct = ui128.ToString(8);
      bits = string.Join("", oct);
      ui128 = UInt128Ex.Parse(bits, 8);
      strbits = ui128.ToString(8);
      if (!strbits.SequenceEqual(bits))
        throw new ArgumentException(null);


      //dec
      bytes = Enumerable.Range(0, Rand.Next(2, 38))
        .Select(x => (byte)Rand.Next(0, 10)).ToArray();
      bytes = TrimFirstSetOneZero(bytes);
      bits = string.Join("", bytes);
      ui128 = UInt128Ex.Parse(bits, 10);
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
      ui128 = UInt128Ex.Parse(bits, 16);
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

      var ui128 = new UInt128(hi, lo);
      var instance = new UInt128Ex(hi, lo);

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

      var ui128 = new UInt128(hi, lo);
      var instance = new UInt128Ex(hi, lo);

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

      var ui128 = new UInt128(hi, lo);
      var instance = new UInt128Ex(hi, lo);

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

      var ui128 = new UInt128(hi, lo);
      var instance = new UInt128Ex(hi, lo);

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

      var ui128 = new UInt128(hi, lo);
      var instance = new UInt128Ex(hi, lo);

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

      var instance = new UInt128Ex(hi, lo);

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

      var instance = new UInt128Ex(hi, lo);

      if (instance == UInt128Ex.MaxValue) instance++;

      if (instance == UInt128Ex.MaxValue)
        throw new ArgumentException(null);


      if (instance == UInt128Ex.MinValue) instance++;

      if (instance == UInt128Ex.MinValue)
        throw new ArgumentException(null);

      instance = 0;
      instance--;

      if (instance == UInt128Ex.MaxValue) instance++;

      if (instance == UInt128Ex.MaxValue)
        throw new ArgumentException(null);


      if (instance == UInt128Ex.MinValue) instance++;

      if (instance == UInt128Ex.MinValue)
        throw new ArgumentException(null);


      //Checked
      //instance = UInt128Ex.MaxValue;
      //checked { instance++; }

      //instance = UInt128Ex.MinValue;
      //checked { instance--; }


      //instance = UInt128Ex.MaxValue;
      //checked { instance += 1; }

      //instance = UInt128Ex.MaxValue;
      //checked { instance = instance + 1; }

      //instance = UInt128Ex.MinValue;
      //checked { instance -= 1; }

      //instance = UInt128Ex.MinValue;
      //checked { instance = instance- 1; }

    }
  }

  private static void TestEquals(int counts)
  {
    for (var i = 0; i < counts; i++)
    {
      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var ui128 = new UInt128(hi, lo);
      var instance1 = new UInt128Ex(hi, lo);
      var instance2 = new UInt128Ex(hi, lo);

      if (!Equal(instance1, ui128))
        throw new ArgumentException(null);

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
  }

  private static void TestGreatLessThan(int counts)
  {
    for (var i = 0; i < counts; i++)
    {
      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var ui128 = new UInt128(hi, lo);
      var instance1 = new UInt128Ex(hi, lo);
      var instance2 = new UInt128Ex(hi, lo);

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

      var instance = new UInt128Ex(hi, lo);

      if (instance == UInt128Ex.MaxValue) instance++;

      if (instance == UInt128Ex.MaxValue)
        throw new ArgumentException(null);

      if (instance == UInt128Ex.MinValue) instance++;

      if (instance == UInt128Ex.MinValue)
        throw new ArgumentException(null);


      //Checked
      //instance = UInt128Ex.MaxValue;
      //checked { instance++; }

      //instance = UInt128Ex.MinValue;
      //checked { instance--; }


      //instance = UInt128Ex.MaxValue;
      //checked { instance += 1; }

      //instance = UInt128Ex.MaxValue;
      //checked { instance = instance + 1; }

      //instance = UInt128Ex.MinValue;
      //checked { instance -= 1; }

      //instance = UInt128Ex.MinValue;
      //checked { instance = instance - 1; }

    }
  }

  private static void TestAddition(int counts)
  {
    for (var i = 0; i < counts; i++)
    {

      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var ui128 = new UInt128(hi, lo);
      var instance = new UInt128Ex(hi, lo);

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);

      var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      ui128 += r; instance += r;

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);

      r = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      ui128 = ui128 + r; instance = instance + r;

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);

      var ir = -Rand.NextInt64();
      ui128 += (ulong)ir; instance += (ulong)ir;

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);




      //Checked
      //ui128 = 0ul; instance = 0ul;

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

      //ui128 = UInt128.MaxValue;
      //instance = UInt128Ex.MaxValue; 
      //r = (ulong)Rand.NextInt64();
      //ui128 = checked(ui128 + r); //overflow
      //instance = checked(instance + r); //overflow

    }
  }

  private static void TestSubtraction(int counts)
  {
    for (var i = 0; i < counts; i++)
    {
      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var ui128 = new UInt128(hi, lo);
      var instance = new UInt128Ex(hi, lo);

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);

      var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      ui128 -= r; instance -= r;

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);

      r = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      ui128 = ui128 - r; instance = instance - r;

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);

      var ir = -Rand.NextInt64();
      ui128 -= (ulong)ir; instance -= (ulong)ir;

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);


      ////Checked
      //ui128 = 0ul; instance = 0ul;

      //r = (ulong)Rand.NextInt64();
      //ui128 = checked(ui128 - r);//overflow
      //instance = checked(instance - r);//overflow

      //ui128 = 0ul; instance = 0ul;
      //ir = -Rand.NextInt64();
      //ui128 = checked(ui128 - (ulong)ir); //overflow
      //instance = checked(instance - (ulong)ir); //overflow

      //ui128 = 0ul; instance = 0ul;
      //r = (ulong)-Rand.NextInt64();
      //ui128 = checked(ui128 - r);//overflow
      //instance = checked(instance - r);//overflow

      //ui128 = UInt128.MaxValue;
      //instance = UInt128Ex.MaxValue;
      //r = (ulong)Rand.NextInt64();
      //ui128 = checked(ui128 - r); 
      //instance = checked(instance - r);  

    }
  }

  private static void TestMultiplication(int counts)
  {
    for (var i = 0; i < counts; i++)
    {
      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var ui128 = new UInt128(hi, lo);
      var instance = new UInt128Ex(hi, lo);

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);

      var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      ui128 *= r; instance *= r;

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);

      r = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      ui128 = ui128 * r; instance = instance * r;

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);

      var ir = -Rand.NextInt64();
      ui128 *= (ulong)ir; instance *= (ulong)ir;

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);


      ////Checked
      //ui128 = 0ul; instance = 0ul;

      //r = (ulong)Rand.NextInt64();
      //ui128 = checked(ui128 * r); 
      //instance = checked(instance * r); 

      //ui128 = 0ul; instance = 0ul;
      //ir = -Rand.NextInt64();
      //ui128 = checked(ui128 * (ulong)ir); //overflow
      //instance = checked(instance * (ulong)ir); //overflow

      //ui128 = 0ul; instance = 0ul;
      //r = (ulong)-Rand.NextInt64();
      //ui128 = checked(ui128 * r); 
      //instance = checked(instance * r); 

      //ui128 = UInt128.MaxValue;
      //instance = UInt128Ex.MaxValue;
      //r = (ulong)Rand.NextInt64();
      //ui128 = checked(ui128 * r);//overflow
      //instance = checked(instance * r);//overflow
    }
  }

  private static void TestDivision(int counts)
  {
    for (var i = 0; i < counts; i++)
    {
      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var ui128 = new UInt128(hi, lo);
      var instance = new UInt128Ex(hi, lo);

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);

      var r = (ulong)Rand.NextInt64();
      ui128 /= r; instance /= r;

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);

      var ir = -Rand.NextInt64();
      ui128 /= (ulong)ir; instance /= (ulong)ir;

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);


      //Checked
      //ui128 = 0ul; instance = 0ul;
      //ui128 /= 0; //overflow
      //instance /= 0;//overflow

      //ui128 = 0ul; instance = 0ul;
      //r = (ulong)Rand.NextInt64();
      //ui128 = checked(ui128 / r);
      //instance = checked(instance / r);

      //ui128 = 0ul; instance = 0ul;
      //ir = -Rand.NextInt64();
      //ui128 = checked(ui128 / (ulong)ir); //overflow
      //instance = checked(instance / (ulong)ir); //overflow

      //ui128 = 0ul; instance = 0ul;
      //r = (ulong)-Rand.NextInt64();
      //ui128 = checked(ui128 / r);
      //instance = checked(instance / r);

      //ui128 = UInt128.MaxValue;
      //instance = UInt128Ex.MaxValue;
      //r = (ulong)Rand.NextInt64();
      //ui128 = checked(ui128 / r);
      //instance = checked(instance / r);

    }
  }

  private static void TestModulo(int counts)
  {
    for (var i = 0; i < counts; i++)
    {
      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var ui128 = new UInt128(hi, lo);
      var instance = new UInt128Ex(hi, lo);

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);

      var r = (ulong)Rand.NextInt64();
      ui128 %= r; instance %= r;

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);

      var ir = -Rand.NextInt64();
      ui128 %= (ulong)ir; instance %= (ulong)ir;

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);

    }
  }

  private static void TestPow(int counts)
  {
    for (var i = 0; i < counts; i++)
    {
      var lo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
      var hi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

      var bi = (BigInteger)lo | ((BigInteger)hi) << 64;
      var instance = new UInt128Ex(hi, lo);

      if (!Equal(instance, bi))
        throw new ArgumentException(null);

      var e = Rand.Next(0, 15);
      bi = BigInteger.Pow(bi, e) % (BigInteger.One << 128);
      instance = UInt128Ex.Pow(instance, e);

      if (!Equal(instance, bi))
        throw new ArgumentException(null);

      e = Rand.Next(0, 128);
      var p2 = UInt128Ex.PowerOfTwo(e, out var overflow);
      if (overflow) throw new ArgumentException(null);

      var bip2 = BigInteger.One << e;

      if (!Equal(p2, bip2))
        throw new ArgumentException(null);

      if (!UInt128Ex.IsPowerTwo(p2))
        throw new ArgumentException(null);

      e = Rand.Next(0, 39);
      var p10 = UInt128Ex.PowerOfTwo(e, out overflow);
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

      var ui128 = new UInt128(hi, lo);
      var instance = new UInt128Ex(hi, lo);

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);

      ui128 = -ui128; instance = -instance;

      if (!Equal(instance, ui128))
        throw new ArgumentException(null);

    }
  }


  private static void TestNsc()
  {
    //ulong ulng;
    var ulngs = new ulong[1];
    var bytes = new byte[] { 0, 0, 1, 2, 3, 4, 0, 0 };
    Buffer.BlockCopy(bytes, 0, ulngs, 0, 8);
    bytes = TrimLastReverse(bytes);

    var expect = "1000000001100000010000000010000000000000000";
    TestDualSystem(bytes, expect);

    expect = "100140200200000";
    TestOctalSystem(bytes, expect);

    expect = "4410965032960";
    TestDecimalSystem(bytes, expect);

    expect = "40302010000";
    TestHexSystem(bytes, expect);


    bytes = new byte[8];
    ulngs = new ulong[] { 66051ul };
    Buffer.BlockCopy(ulngs, 0, bytes, 0, 8);
    bytes = TrimLastReverse(bytes);

    expect = "10000001000000011";
    TestDualSystem(bytes, expect);

    expect = "201003";
    TestOctalSystem(bytes, expect);

    expect = "66051";
    TestDecimalSystem(bytes, expect);

    expect = "10203";
    TestHexSystem(bytes, expect);

    var count = 500;

    for (var i = 0; i < count; i++)
    {
      bytes = new byte[8];
      ulngs = new ulong[] { (ulong)Rand.NextInt64() };
      Buffer.BlockCopy(ulngs, 0, bytes, 0, 8);
      bytes = TrimLastReverse(bytes);

      expect = Convert.ToHexString(bytes).ToUpper();
      //ulng = ulngs[0]; //https://www.rapidtables.com/convert/number/decimal-to-hex.html
      TestHexSystem(bytes, expect);
    }
  }

  private static void TestDualSystem(byte[] bytes, string expect)
  {
    //Wenn es sich um eine positive Zahl handelt,
    //kriegen die Bits eine 0 vorne angehängt.

    var bits = Nsc(bytes, 256, 2);
    var str = '0' + string.Join("", bits);

    if (!str.AsSpan(1, str.Length - 1).SequenceEqual(expect))
      throw new ArgumentException(null);

    var b = str.Select(s => byte.Parse(s.ToString())).Skip(1).ToArray();
    var r = Nsc(b, 2, 256);

    if (!r.SequenceEqual(bytes))
      throw new ArgumentException(null);
  }

  private static void TestDecimalSystem(byte[] bytes, string expect)
  {
    var dec = Nsc(bytes, 256, 10);
    var str = string.Join("", dec);

    if (!str.SequenceEqual(expect))
      throw new ArgumentException(null);

    var b = str.Select(s => byte.Parse(s.ToString())).ToArray();
    var r = Nsc(b, 10, 256);

    if (!r.SequenceEqual(bytes))
      throw new ArgumentException(null);
  }

  private static void TestOctalSystem(byte[] bytes, string expect)
  {
    var oct = Nsc(bytes, 256, 8);
    var str = string.Join("", oct);

    if (!str.SequenceEqual(expect))
      throw new ArgumentException(null);

    var b = str.Select(s => byte.Parse(s.ToString())).ToArray();
    var r = Nsc(b, 8, 256);

    if (!r.SequenceEqual(bytes))
      throw new ArgumentException(null);
  }

  private static void TestHexSystem(byte[] bytes, string expect)
  {
    var h = "0123456789ABCDEF";

    var str = new StringBuilder();
    var hex = Nsc(bytes, 256, 16);

    for (var i = 0; i < hex.Length; i++)
      str.Append(h[hex[i]]);

    //Es kann vorkommen das 'Convert.ToHexString'
    //(expect) eine 0 an erster Stelle setzt.
    if (str.Length != expect.Length)
      str.Insert(0, 0);

    if (!str.ToString().SequenceEqual(expect))
      throw new ArgumentException(null);

    var dict = new Dictionary<char, byte>();
    for (byte i = 0; i < h.Length; i++)
      dict[h[i]] = i;

    var b = str.ToString().Select(s => dict[s]).ToArray();
    var r = Nsc(b, 16, 256);

    if (!r.SequenceEqual(bytes))
      throw new ArgumentException(null);
  }

  private static byte[] Nsc(byte[] data, int startbase, int targetbase)
  {
    int cap = Convert.ToInt32(data.Length * Math.Log(startbase) / Math.Log(targetbase)) + 1;
    var result = new Stack<byte>(cap);

    byte remainder;
    bool ext = true;
    byte accumulator;
    var input = data.ToArray();
    while (ext)
    {
      remainder = 0; ext = false;
      for (int i = 0; i < input.Length; i++)
      {
        accumulator = (byte)(((startbase * remainder) + input[i]) % targetbase);
        input[i] = (byte)(((startbase * remainder) + input[i]) / targetbase);
        remainder = accumulator;
        if (input[i] > 0) ext = true;
      }
      result.Push(remainder);
    }
    return result.ToArray();
  }

  private static byte[] TrimLastReverse(byte[] data)
  {
    var count = 0;
    var length = data.Length;
    for (var i = length - 1; i >= 0; i--)
      if (data[i] == 0) { count++; }
      else break;

    return data.Take(length - count).Reverse().ToArray();
  }

  private static bool Equal(UInt128Ex left, UInt128 right)
  {
    return left.ToString().SequenceEqual(right.ToString());
  }

  private static bool Equal(UInt128Ex left, BigInteger right)
  {
    return left.ToString().SequenceEqual(right.ToString());
  }

  public static string ToBinaryString(BigInteger bigint)
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

  public static string ToHexadecimalString(BigInteger bigint)
  {
    //https://stackoverflow.com/a/15447131
    return bigint.ToString("X");
  }


  public static string ToOctalString(BigInteger bigint)
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
}



