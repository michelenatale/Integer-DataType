
Option Strict On
Option Explicit On

Imports System.Runtime.InteropServices
Imports michele.natale.Numbers

Namespace TestUIntX

  Public Module TestUInt256Ex

    Public Sub Start()

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
      Dim type_size = Marshal.SizeOf(Of UInt256Ex)
    End Sub

    Private Sub TestInstance()
      Dim instance = New UInt256Ex()

      'unsigned

      Dim ui32 As UInteger = 5
      instance = New UInt256Ex(ui32)

      Dim ui64 As ULong = 5
      instance = New UInt256Ex(ui64)

      'signed

      Dim i32 = 5
      instance = New UInt256Ex(i32) 'Convert.ToInt64(i32)

      Dim instance2 = New UInt256Ex(instance)
    End Sub

    Private Sub TestConverts()

      'unchecked

      Dim ui16 As UShort = 5
      Dim instance = CType(ui16, UInt256Ex)


      Dim flt = 5.0F
      instance = CType(flt, UInt256Ex)

      flt = -flt
      instance = CType(flt, UInt256Ex)

      Dim dbl = 5.0
      instance = CType(dbl, UInt256Ex)

      Dim dec = -5D
      instance = CType(dec, UInt256Ex)
    End Sub

    Private Sub TestMethodes()
      Dim llo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim lhi = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rlo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rhi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt256Ex(rhi, rlo, lhi, llo)
      Dim bspan = instance.ToSpan()

      Dim bytes = instance.ToBytes()

      bytes = instance.ToBytes(False)

      Dim values = instance.ToValues()

      values = instance.ToValues(False)

      Dim ui128 = UInt256Ex.ToUInt256Ex(instance.ToBytes())

      ui128 = UInt256Ex.ToUInt256Ex(instance.ToValues())
    End Sub

    Private Sub TestToString()

      Dim llo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim lhi = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rlo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rhi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt256Ex(rhi, rlo, lhi, llo)
      Dim binstr = instance.ToString(2)
      Dim octstr = instance.ToString(8)
      Dim decstr = instance.ToString(10)
      Dim hexstr = instance.ToString(16)

      Dim ui128 = UInt256Ex.Parse(binstr, 2)

      ui128 = UInt256Ex.Parse(octstr, 8)

      ui128 = UInt256Ex.Parse(decstr, 10)

      ui128 = UInt256Ex.Parse(hexstr, 16)
    End Sub

    Private Sub TestParse()
      Dim llo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim lhi = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rlo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rhi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt256Ex(rhi, rlo, lhi, llo)

      Dim ui = CUInt(instance)
      Dim ll = CLng(instance)

      If ui <> Convert.ToUInt32(instance) Then Throw New ArgumentException(Nothing)
      If ll <> Convert.ToInt64(instance) Then Throw New ArgumentException(Nothing)
    End Sub

    Private Sub TestParseString()

      Dim llo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim lhi = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rlo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rhi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt256Ex(rhi, rlo, lhi, llo)
      Dim binstr = instance.ToString(2)
      Dim octstr = instance.ToString(8)
      Dim decstr = instance.ToString(10)
      Dim hexstr = instance.ToString(16)

      Dim ui128_1 = UInt256Ex.Parse(binstr, 2)
      Dim ui128_2 = UInt256Ex.Parse(octstr, 8)
      Dim ui128_3 = UInt256Ex.Parse(decstr, 10)
      Dim ui128_4 = UInt256Ex.Parse(hexstr, 16)

      'bin
      Dim bytes = Enumerable.Range(CInt(0), Rand.[Next](CInt(2), CInt(129))).[Select](Function(x) CByte(CByte(Rand.[Next](CInt(0), CInt(2))))).ToArray()
      bytes = TrimFirstSetOneZero(bytes)
      Dim bits = String.Join("", bytes)
      Dim ui128 = UInt256Ex.Parse(bits, 2)
      Dim strbits = ui128.ToString(2)

      'Oct-Systeme können nicht frei gerandomt werden.
      bytes = Enumerable.Range(CInt(0), Rand.[Next](CInt(2), CInt(129))).[Select](Function(x) CByte(CByte(Rand.[Next](CInt(0), CInt(2))))).ToArray()
      bytes = TrimFirstSetOneZero(bytes)
      bits = String.Join("", bytes)
      ui128 = UInt256Ex.Parse(bits, 2)

      Dim oct = ui128.ToString(8)
      bits = String.Join("", oct)
      ui128 = UInt256Ex.Parse(bits, 8)
      strbits = ui128.ToString(8)

      'dec
      bytes = Enumerable.Range(CInt(0), Rand.[Next](CInt(2), CInt(38))).[Select](Function(x) CByte(CByte(Rand.[Next](CInt(0), CInt(10))))).ToArray()
      bytes = TrimFirstSetOneZero(bytes)
      bits = String.Join("", bytes)
      ui128 = UInt256Ex.Parse(bits, 10)
      strbits = ui128.ToString(10)

      'Hex
      bytes = Enumerable.Range(CInt(0), Rand.[Next](CInt(2), CInt(33))).[Select](Function(x) CByte(CByte(Rand.[Next](CInt(0), CInt(16))))).ToArray()

      Dim hex = "0123456789ABCDEF"
      bytes = TrimFirstSetOneZero(bytes)
      bits = String.Join("", bytes.[Select](Function(s) hex(s)))
      ui128 = UInt256Ex.Parse(bits, 16)
      strbits = ui128.ToString(16)
    End Sub

    Private Sub TestBitwiseNot()

      'Complement

      Dim llo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim lhi = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rlo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rhi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt256Ex(rhi, rlo, lhi, llo)

      Dim r = CULng(CULng(Rand.Next()) * Rand.Next())
      instance += r

      Dim result2 = Not instance
    End Sub

    Private Sub TestBitwiseAnd()
      Dim llo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim lhi = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rlo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rhi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt256Ex(rhi, rlo, lhi, llo)

      Dim number = CULng(CULng(Rand.Next()) * Rand.Next())
      instance += number

      Dim r = CULng(CULng(Rand.Next()) * Rand.Next())

      instance = instance And r
    End Sub

    Private Sub TestBitwiseOr()
      Dim llo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim lhi = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rlo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rhi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt256Ex(rhi, rlo, lhi, llo)

      Dim number = CULng(CULng(Rand.Next()) * Rand.Next())
      instance += number

      Dim r = CULng(CULng(Rand.Next()) * Rand.Next())

      instance = instance Or r
    End Sub

    Private Sub TestBitwiseXor()

      Dim llo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim lhi = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rlo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rhi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt256Ex(rhi, rlo, lhi, llo)

      Dim number = CULng(CULng(Rand.Next()) * Rand.Next())
      instance += number

      Dim r = CULng(CULng(Rand.Next()) * Rand.Next())

      instance = instance Xor r
    End Sub

    Private Sub TestBitwiseShift()

      Dim llo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim lhi = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rlo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rhi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt256Ex(rhi, rlo, lhi, llo)

      Dim number = CULng(CULng(Rand.Next()) * Rand.Next())
      instance += number

      Dim l = 1 + CInt(Double.Truncate(Math.Log10(Math.Pow(2, 128))))
      Dim r = Rand.[Next](0, l)

      instance <<= r


      r = Rand.[Next](0, l)

      instance >>= r

      r = Rand.[Next](0, l)
      'ui128 >>>= r 
      instance = UInt256Ex.op_UnsignedRightShift(instance, r)

    End Sub

    Private Sub TestIsZeroOne()

      Dim llo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim lhi = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rlo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rhi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt256Ex(rhi, rlo, lhi, llo)

      If instance.IsZero Then instance += 1UI

      If instance.IsOne Then instance += 1UI

      If instance.IsMinusOne Then instance -= 1UI

      instance = CType(0, UInt256Ex)
      Dim bool_1 = instance.IsZero

      instance += 1UI
      Dim bool_2 = instance.IsOne

      instance -= 1UI
      instance -= 1UI
      Dim bool_3 = instance.IsMinusOne
    End Sub

    Private Sub TestIsMinMax()

      Dim llo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim lhi = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rlo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rhi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt256Ex(rhi, rlo, lhi, llo)

      If instance = UInt256Ex.MaxValue Then instance += 1UI
      If instance = UInt256Ex.MinValue Then instance += 1UI

      instance = CType(0, UInt256Ex)
      instance -= 1UI

      If instance = UInt256Ex.MaxValue Then instance += 1UI
      If instance = UInt256Ex.MinValue Then instance += 1UI
    End Sub

    Private Sub TestEquals()


      Dim llo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim lhi = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rlo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rhi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance1 = New UInt256Ex(rhi, rlo, lhi, llo)
      Dim instance2 = New UInt256Ex(rhi, rlo, lhi, llo)

      If Not instance1.Equals(instance2) Then Throw New ArgumentException(Nothing)

      Dim ainstance1 = New UInt256Ex() {CULng(CULng(Rand.Next()) * Rand.Next()), CULng(CULng(Rand.Next()) * Rand.Next()), CULng(CULng(Rand.Next()) * Rand.Next()), CULng(CULng(Rand.Next()) * Rand.Next())}

      Dim ainstance2 = ainstance1.ToArray()

      If Not ainstance1.SequenceEqual(ainstance2) Then Throw New ArgumentException(Nothing)

      ainstance2(0) += 1UI

      If ainstance1.SequenceEqual(ainstance2) Then Throw New ArgumentException(Nothing)
    End Sub

    Private Sub TestGreatLessThan()

      Dim llo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim lhi = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rlo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rhi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance1 = New UInt256Ex(rhi, rlo, lhi, llo)
      Dim instance2 = New UInt256Ex(rhi, rlo, lhi, llo)

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

      instance1 += CType(10, UInt256Ex)
      If instance1 > instance2 Then
      Else
        Throw New ArgumentException(Nothing)
      End If

      instance1 -= CType(20, UInt256Ex)
      If instance1 < instance2 Then
      Else
        Throw New ArgumentException(Nothing)
      End If
    End Sub

    Private Sub TestIteration()

      Dim instance = New UInt256Ex()

      instance += 1UI
      instance -= 1UI
    End Sub

    Private Sub TestAddition()

      Dim llo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim lhi = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rlo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rhi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt256Ex(rhi, rlo, lhi, llo)

      Dim r = CULng(CULng(Rand.Next()) * Rand.Next())
      instance += r
    End Sub

    Private Sub TestSubtraction()

      Dim llo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim lhi = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rlo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rhi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt256Ex(rhi, rlo, lhi, llo)
      Dim r = CULng(CULng(Rand.Next()) * Rand.Next())

      instance -= r
    End Sub

    Private Sub TestMultiplication()

      Dim llo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim lhi = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rlo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rhi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt256Ex(rhi, rlo, lhi, llo)

      Dim r = CULng(CULng(Rand.Next()) * Rand.Next())
      instance *= r
    End Sub

    Private Sub TestDivision()

      Dim llo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim lhi = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rlo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rhi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt256Ex(rhi, rlo, lhi, llo)

      Dim r = CULng(Rand.NextInt64())
      instance /= r

    End Sub

    Private Sub TestModulo()

      Dim llo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim lhi = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rlo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rhi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt256Ex(rhi, rlo, lhi, llo)

      Dim r = CULng(Rand.NextInt64())
      instance = instance Mod r
    End Sub

    Private Sub TestPow()

      Dim llo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim lhi = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rlo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rhi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt256Ex(rhi, rlo, lhi, llo)

      Dim e = Rand.[Next](0, 15)
      instance = UInt256Ex.Pow(instance, e)

      e = Rand.[Next](0, 128)
      Dim overflow As Boolean
      Dim p2 = UInt256Ex.PowerOfTwo(e, overflow)
      If overflow Then Throw New ArgumentException(Nothing)

      If Not UInt256Ex.IsPowerTwo(p2) Then Throw New ArgumentException(Nothing)

      e = Rand.[Next](0, 39)
      Dim p10 = UInt256Ex.PowerOfTen(e, overflow)
      If overflow Then Throw New ArgumentException(Nothing)
    End Sub

    Private Sub TestNegate()

      Dim llo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim lhi = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rlo = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim rhi = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New UInt256Ex(rhi, rlo, lhi, llo)

      instance = -instance
    End Sub

    Private Function TrimFirstSetOneZero(bytes As Byte()) As Byte()
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
