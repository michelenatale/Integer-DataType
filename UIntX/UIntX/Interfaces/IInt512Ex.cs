


namespace michele.natale.Numbers;


/// <summary>Defines a mechanism for Operations.</summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
internal interface IInt512Ex<TSelf>
   where TSelf : IInt512Ex<TSelf>
{

  /// <summary>
  /// Returns a Instance from Int512Ex
  /// </summary>
  /// <param name="bytes">Preset bits.</param> 
  /// <param name="littleendian">Preset Endians of the bytes (bits).</param> 
  public abstract static TSelf ToInt512Ex(ReadOnlySpan<byte> bytes, bool littleendian = true);

  /// <summary>
  /// Returns a Instance from Int512Ex
  /// </summary>
  /// <param name="uints">Preset bits.</param> 
  /// <param name="littleendian">Preset Endians of the uints (bits).</param> 
  public abstract static TSelf ToInt512Ex(ReadOnlySpan<uint> uints, bool littleendian = true);

  /// <summary>
  /// Returns a Instance from Int512Ex
  /// </summary>
  /// <param name="ulongs">Preset bits.</param> 
  /// <param name="littleendian">Preset Endians of the ulongs (bits).</param> 
  public abstract static TSelf ToInt512Ex(ReadOnlySpan<ulong> ulongs, bool littleendian = true);

}


