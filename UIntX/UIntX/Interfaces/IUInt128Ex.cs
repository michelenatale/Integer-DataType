


namespace michele.natale.Numbers;


/// <summary>Defines a mechanism for Operations.</summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
internal interface IUInt128Ex<TSelf>
   where TSelf : IUInt128Ex<TSelf>
{

  /// <summary>
  /// Returns a Instance from UInt128Ex
  /// </summary>
  /// <param name="bytes">Preset bits.</param> 
  /// <param name="littleendian">Preset Endians of the bytes (bits).</param> 
  public abstract static TSelf ToUInt128Ex(ReadOnlySpan<byte> bytes, bool littleendian = true);

  /// <summary>
  /// Returns a Instance from UInt128Ex
  /// </summary>
  /// <param name="uints">Preset bits.</param> 
  /// <param name="littleendian">Preset Endians of the uints (bits).</param> 
  public abstract static TSelf ToUInt128Ex(ReadOnlySpan<uint> uints, bool littleendian = true);

  /// <summary>
  /// Returns a Instance from UInt128Ex
  /// </summary>
  /// <param name="ulongs">Preset bits.</param> 
  /// <param name="littleendian">Preset Endians of the ulongs (bits).</param> 
  public abstract static TSelf ToUInt128Ex(ReadOnlySpan<ulong> ulongs, bool littleendian = true);

}


