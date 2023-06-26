


namespace michele.natale.Numbers;


/// <summary>
/// Interface for UIntExOfT
/// </summary>
/// <typeparam name="T">The type that implements this interface.</typeparam>
internal interface IUIntExConversion<T>
  where T : IUIntExConversion<T>
{
  public TypeCode GetTypeCode();

  public bool ToBoolean(IFormatProvider? provider);

  public byte ToByte(IFormatProvider? provider);

  public char ToChar(IFormatProvider? provider);

  public DateTime ToDateTime(IFormatProvider? provider);

  public decimal ToDecimal(IFormatProvider? provider);

  public double ToDouble(IFormatProvider? provider);

  public short ToInt16(IFormatProvider? provider);

  public int ToInt32(IFormatProvider? provider);

  public long ToInt64(IFormatProvider? provider);

  public sbyte ToSByte(IFormatProvider? provider);

  public float ToSingle(IFormatProvider? provider);

  public ushort ToUInt16(IFormatProvider? provider);

  public uint ToUInt32(IFormatProvider? provider);

  public ulong ToUInt64(IFormatProvider? provider);


  public abstract static explicit operator byte(T value);

  public virtual static explicit operator checked byte(T value) => throw new NotImplementedException();


  public abstract static explicit operator ushort(T value);

  public virtual static explicit operator checked ushort(T value) => throw new NotImplementedException();


  public abstract static explicit operator uint(T value);

  public virtual static explicit operator checked uint(T value) => throw new NotImplementedException();


  public abstract static explicit operator ulong(T value);

  public virtual static explicit operator checked ulong(T value) => throw new NotImplementedException();


  public abstract static explicit operator char(T value);

  public virtual static explicit operator checked char(T value) => throw new NotImplementedException();



  public abstract static explicit operator sbyte(T value);

  public virtual static explicit operator checked sbyte(T value) => throw new NotImplementedException();


  public abstract static explicit operator short(T value);

  public virtual static explicit operator checked short(T value) => throw new NotImplementedException();


  public abstract static explicit operator int(T value);

  public virtual static explicit operator checked int(T value) => throw new NotImplementedException();


  public abstract static explicit operator long(T value);

  public virtual static explicit operator checked long(T value) => throw new NotImplementedException();


  public abstract static explicit operator double(T value);

  public virtual static explicit operator checked double(T value) => throw new NotImplementedException();


  public abstract static explicit operator decimal(T value);

  public virtual static explicit operator checked decimal(T value) => throw new NotImplementedException();


  public abstract static explicit operator float(T value);

  public virtual static explicit operator checked float(T value) => throw new NotImplementedException();
}


