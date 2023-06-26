
Option Strict On
Option Explicit On

Imports System.Runtime.InteropServices
Imports michele.natale.Numbers

Namespace TestUIntX

  Public Module TestUInt128Ex


    Public Sub Start()
      'TestNsc();

      TestSizeOf()
      TestInstance()
      TestConverts()

      TestMethodes()
      TestToString()
      TestParse()
      TestParseString()
      TestBitwise()

      TestOperation()
    End Sub


    Private Sub TestBitwise()
      TestBitwiseNot() ' OneComplement
      TestBitwiseAnd()
      TestBitwiseOr()
      TestBitwiseXor()
      TestBitwiseShift()
    End Sub

    Private Sub TestOperation()
      TestIsZeroOne()
      TestIsMinMax()
      TestEquals()
      TestGreatLessThan()
      TestIteration()

      TestNumericOperators()
    End Sub

    Private Sub TestNumericOperators()
      TestAddition()
      TestSubtraction()
      TestMultiplication()
      TestDivision()
      TestModulo()
      TestPow()
      TestNegate()
    End Sub

    Private Sub TestSizeOf()
      Dim type_size = Marshal.SizeOf(Of UInt128Ex)
    End Sub

    Private Sub TestInstance()
      Dim instance = New UInt128Ex()

      'unsigned

      Dim ui32 As UInteger = 5
      instance = New UInt128Ex(ui32)

      'signed

      Dim i32 = 5
      instance = New UInt128Ex(Convert.ToInt64(i32))
    End Sub

    Private Sub TestConverts()

      'unchecked

      Dim ui16 As UShort = 5
      Dim instance = CType(ui16, UInt128Ex)


      Dim flt = 5.0F
      instance = CType(flt, UInt128Ex)

      flt = -flt
      instance = CType(flt, UInt128Ex)

      Dim dbl = 5.0
      instance = CType(dbl, UInt128Ex)

      Dim dec = -5D
      instance = CType(dec, UInt128Ex)
    End Sub

    Private Sub TestMethodes()
      Dim lo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim hi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt128Ex(hi, lo)
      Dim bspan = instance.ToSpan()

      Dim bytes = instance.ToBytes()

      bytes = instance.ToBytes(False)

      Dim values = instance.ToValues()

      values = instance.ToValues(False)

      Dim ui128 = UInt128Ex.ToUInt128Ex(instance.ToBytes())

      ui128 = UInt128Ex.ToUInt128Ex(instance.ToValues())
    End Sub

    Private Sub TestToString()

      Dim lo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim hi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt128Ex(lo, hi)
      Dim binstr = instance.ToString(2)
      Dim octstr = instance.ToString(8)
      Dim decstr = instance.ToString(10)
      Dim hexstr = instance.ToString(16)

      Dim ui128 = UInt128Ex.FromDualSystem(binstr)

      ui128 = UInt128Ex.FromOctalSystem(octstr)

      ui128 = UInt128Ex.FromDecimalSystem(decstr)

      ui128 = UInt128Ex.FromHexSystem(hexstr)
    End Sub

    Private Sub TestParse()
      Dim lo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim hi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim ui218 = New UInt128(hi, lo)
      Dim instance = New UInt128Ex(hi, lo)
      Dim ui = CUInt(instance)
      Dim ll = CLng(instance)

      If ui <> Convert.ToUInt32(instance) Then Throw New ArgumentException(Nothing)
      If ll <> Convert.ToInt64(instance) Then Throw New ArgumentException(Nothing)

      If ui <> CUInt(ui218) Then Throw New ArgumentException(Nothing)
      If ll <> CLng(ui218) Then Throw New ArgumentException(Nothing)
    End Sub

    Private Sub TestParseString()

      Dim lo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim hi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt128Ex(lo, hi)
      Dim binstr = instance.ToString(2)
      Dim octstr = instance.ToString(8)
      Dim decstr = instance.ToString(10)
      Dim hexstr = instance.ToString(16)

      Dim ui128_1 = UInt128Ex.Parse(binstr, 2)
      Dim ui128_2 = UInt128Ex.Parse(octstr, 8)
      Dim ui128_3 = UInt128Ex.Parse(decstr, 10)
      Dim ui128_4 = UInt128Ex.Parse(hexstr, 16)

      'bin
      Dim bytes = Enumerable.Range(CInt(0), Rand.[Next](CInt(2), CInt(129))).[Select](Function(x) CByte(CByte(Rand.[Next](CInt(0), CInt(2))))).ToArray()
      bytes = TrimFirstSetOneZero(bytes)
      Dim bits = String.Join("", bytes)
      Dim ui128 = UInt128Ex.Parse(bits, 2)
      Dim strbits = ui128.ToString(2)

      'Oct-Systeme können nicht frei gerandomt werden.
      bytes = Enumerable.Range(CInt(0), Rand.[Next](CInt(2), CInt(129))).[Select](Function(x) CByte(CByte(Rand.[Next](CInt(0), CInt(2))))).ToArray()
      bytes = TrimFirstSetOneZero(bytes)
      bits = String.Join("", bytes)
      ui128 = UInt128Ex.Parse(bits, 2)

      Dim oct = ui128.ToString(8)
      bits = String.Join("", oct)
      ui128 = UInt128Ex.Parse(bits, 8)
      strbits = ui128.ToString(8)

      'dec
      bytes = Enumerable.Range(CInt(0), Rand.[Next](CInt(2), CInt(38))).[Select](Function(x) CByte(CByte(Rand.[Next](CInt(0), CInt(10))))).ToArray()
      bytes = TrimFirstSetOneZero(bytes)
      bits = String.Join("", bytes)
      ui128 = UInt128Ex.Parse(bits, 10)
      strbits = ui128.ToString(10)

      'Hex
      bytes = Enumerable.Range(CInt(0), Rand.[Next](CInt(2), CInt(33))).[Select](Function(x) CByte(CByte(Rand.[Next](CInt(0), CInt(16))))).ToArray()

      Dim hex = "0123456789ABCDEF"
      bytes = TrimFirstSetOneZero(bytes)
      bits = String.Join("", bytes.[Select](Function(s) hex(s)))
      ui128 = UInt128Ex.Parse(bits, 16)
      strbits = ui128.ToString(16)
    End Sub

    Private Sub TestBitwiseNot()

      'Complement

      Dim lo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim hi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim ui128 = New UInt128(hi, lo)
      Dim instance = New UInt128Ex(hi, lo)

      Dim r = CULng(CULng(Rand.Next()) * Rand.Next())
      ui128 += r
      instance += r

      Dim result1 = Not ui128
      Dim result2 = Not instance
    End Sub

    Private Sub TestBitwiseAnd()
      Dim lo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim hi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim ui128 = New UInt128(hi, lo)
      Dim instance = New UInt128Ex(hi, lo)

      Dim number = CULng(CULng(Rand.Next()) * Rand.Next())
      ui128 += number
      instance += number

      Dim r = CULng(CULng(Rand.Next()) * Rand.Next())

      ui128 = ui128 And r
      instance = instance And r
    End Sub

    Private Sub TestBitwiseOr()
      Dim lo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim hi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim ui128 = New UInt128(hi, lo)
      Dim instance = New UInt128Ex(hi, lo)

      Dim number = CULng(CULng(Rand.Next()) * Rand.Next())
      ui128 += number
      instance += number

      Dim r = CULng(CULng(Rand.Next()) * Rand.Next())

      ui128 = ui128 Or r
      instance = instance Or r
    End Sub

    Private Sub TestBitwiseXor()
      Dim lo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim hi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim ui128 = New UInt128(hi, lo)
      Dim instance = New UInt128Ex(hi, lo)

      Dim number = CULng(CULng(Rand.Next()) * Rand.Next())
      ui128 += number
      instance += number

      Dim r = CULng(CULng(Rand.Next()) * Rand.Next())

      ui128 = ui128 Xor r
      instance = instance Xor r
    End Sub

    Private Sub TestBitwiseShift()
      Dim lo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim hi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim ui128 = New UInt128(hi, lo)
      Dim instance = New UInt128Ex(hi, lo)

      Dim number = CULng(CULng(Rand.Next()) * Rand.Next())
      ui128 += number
      instance += number

      Dim l = 1 + CInt(Double.Truncate(Math.Log10(Math.Pow(2, 128))))
      Dim r = Rand.[Next](0, l)

      ui128 <<= r
      instance <<= r


      r = Rand.[Next](0, l)

      ui128 >>= r
      instance >>= r


      'r = Rand.[Next](0, l)
      'ui128 >>>= r 

    End Sub

    Private Sub TestIsZeroOne()
      Dim lo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim hi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt128Ex(hi, lo)

      If instance.IsZero Then instance += 1UI

      If instance.IsOne Then instance += 1UI

      If instance.IsMinusOne Then instance -= 1UI

      instance = CType(0, UInt128Ex)
      Dim bool_1 = instance.IsZero

      instance += 1UI
      Dim bool_2 = instance.IsOne

      instance -= 1UI
      instance -= 1UI
      Dim bool_3 = instance.IsMinusOne
    End Sub

    Private Sub TestIsMinMax()

      Dim lo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim hi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt128Ex(hi, lo)

      If instance = UInt128Ex.MaxValue Then instance += 1UI
      If instance = UInt128Ex.MinValue Then instance += 1UI

      instance = CType(0, UInt128Ex)
      instance -= 1UI

      If instance = UInt128Ex.MaxValue Then instance += 1UI
      If instance = UInt128Ex.MinValue Then instance += 1UI
    End Sub

    Private Sub TestEquals()

      Dim lo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim hi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance1 = New UInt128Ex(hi, lo)
      Dim instance2 = New UInt128Ex(hi, lo)

      If Not instance1.Equals(instance2) Then Throw New ArgumentException(Nothing)

      Dim ainstance1 = New UInt128Ex() {CULng(CULng(Rand.Next()) * Rand.Next()), CULng(CULng(Rand.Next()) * Rand.Next()), CULng(CULng(Rand.Next()) * Rand.Next()), CULng(CULng(Rand.Next()) * Rand.Next())}

      Dim ainstance2 = ainstance1.ToArray()

      If Not ainstance1.SequenceEqual(ainstance2) Then Throw New ArgumentException(Nothing)

      ainstance2(0) += 1UI

      If ainstance1.SequenceEqual(ainstance2) Then Throw New ArgumentException(Nothing)
    End Sub

    Private Sub TestGreatLessThan()
      Dim lo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim hi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance1 = New UInt128Ex(hi, lo)
      Dim instance2 = New UInt128Ex(hi, lo)

      If Not instance1 = instance2 Then Throw New ArgumentException(Nothing)

      If instance1 >= instance2 Then
      Else
        Throw New ArgumentException(Nothing)
      End If

      instance1 += 1UI


      If instance1 >= instance2 Then
      Else
        Throw New ArgumentException(Nothing)
      End If

      instance1 -= 1UI
      instance1 -= 1UI


      If instance1 <= instance2 Then
      Else
        Throw New ArgumentException(Nothing)
      End If

      instance1 -= 1UI

      If instance1 <= instance2 Then
      Else
        Throw New ArgumentException(Nothing)
      End If

      instance1 += CType(10, UInt128Ex)
      If instance1 > instance2 Then
      Else
        Throw New ArgumentException(Nothing)
      End If

      instance1 -= CType(20, UInt128Ex)
      If instance1 < instance2 Then
      Else
        Throw New ArgumentException(Nothing)
      End If
    End Sub

    Private Sub TestIteration()
      Dim lo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim hi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt128Ex()

      instance += 1UI
      instance -= 1UI
    End Sub

    Private Sub TestAddition()
      Dim lo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim hi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt128Ex(hi, lo)

      Dim r = CULng(CULng(Rand.Next()) * Rand.Next())
      instance += r
    End Sub

    Private Sub TestSubtraction()
      Dim lo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim hi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt128Ex(hi, lo)
      Dim r = CULng(CULng(Rand.Next()) * Rand.Next())

      instance -= r
    End Sub

    Private Sub TestMultiplication()
      Dim lo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim hi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt128Ex(hi, lo)

      Dim r = CULng(CULng(Rand.Next()) * Rand.Next())
      instance *= r
    End Sub

    Private Sub TestDivision()
      Dim lo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim hi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt128Ex(hi, lo)

      Dim r = CULng(Rand.NextInt64())
      instance /= r

    End Sub

    Private Sub TestModulo()
      Dim lo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim hi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt128Ex(hi, lo)

      Dim r = CULng(Rand.NextInt64())
      instance = instance Mod r
    End Sub

    Private Sub TestPow()
      Dim lo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim hi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt128Ex()

      Dim e = Rand.[Next](0, 15)
      instance = UInt128Ex.Pow(instance, e)

      e = Rand.[Next](0, 128)
      Dim overflow As Boolean
      Dim p2 = UInt128Ex.PowerOfTwo(e, overflow)
      If overflow Then Throw New ArgumentException(Nothing)

      If Not UInt128Ex.IsPowerTwo(p2) Then Throw New ArgumentException(Nothing)

      e = Rand.[Next](0, 39)
      Dim p10 = UInt128Ex.PowerOfTwo(e, overflow)
      If overflow Then Throw New ArgumentException(Nothing)
    End Sub

    Private Sub TestNegate()
      Dim lo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim hi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt128Ex(hi, lo)

      instance = -instance
    End Sub

    Private Function TrimFirstSetOneZero(ByVal bytes As Byte()) As Byte()
      If bytes.Length < 3 Then Return New Byte(1) {0, 1}

      Dim count = 0
      Dim length = bytes.Length
      For i = 0 To length - 1
        If bytes(i) = 0 Then
          count += 1
        Else Exit For
        End If
      Next

      If count = bytes.Length Then Return New Byte(1) {0, 1}
      If count = 1 Then Return bytes.ToArray()
      If count = 0 Then Return New Byte(0) {}.Concat(bytes.ToArray()).ToArray()
      'Return bytes.Slice(count - 1, bytes.Length - count + 1).ToArray()
      Return bytes.Skip(count - 1).Take(bytes.Length - count + 1).ToArray()
    End Function

  End Module

End Namespace
