Option Strict On
Option Explicit On
Imports System.Runtime.InteropServices
Imports michele.natale.Numbers

Namespace TestUIntX

  Public Module TestInt512Ex

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
      Dim type_size = Marshal.SizeOf(Of Int512Ex)
    End Sub
    Private Sub TestInstance()
      Dim instance = New Int512Ex()


      'unsigned 
      Dim ui32 As UInteger = 5
      instance = New Int512Ex(ui32)


      'signed 
      Dim i32 = 5
      instance = New Int512Ex(i32)

      instance = New Int512Ex(-i32)
    End Sub

    Private Sub TestConverts()

      'unchecked

      Dim ui32 As UInteger = 5
      Dim instance = CType(ui32, Int512Ex)

      Dim i32 = 5
      instance = CType(i32, Int512Ex)
      i32 = -i32
      instance = CType(i32, Int512Ex)


      Dim flt = 5.0F
      instance = CType(flt, Int512Ex)
      flt = -flt
      instance = CType(flt, Int512Ex)

      Dim dbl = 5.0
      instance = CType(dbl, Int512Ex)
      dbl = -dbl
      instance = CType(dbl, Int512Ex)

      Dim dec = 5D
      instance = CType(dec, Int512Ex)
      dec = -dec
      instance = CType(dec, Int512Ex)


      'checked  

      i32 = 5
      instance = CType(i32, Int512Ex)
      i32 = -i32
      instance = CType(i32, Int512Ex)

      flt = 5.0F
      instance = CType(flt, Int512Ex)

      flt = -flt
      instance = CType(flt, Int512Ex)

      dec = 5D
      instance = CType(dec, Int512Ex)
      dec = -dec
      instance = CType(dec, Int512Ex)

      dbl = 5.0
      instance = CType(dbl, Int512Ex)
      dbl = -dbl
      instance = CType(dbl, Int512Ex)
    End Sub

    Private Sub TestMethodes()
      Dim v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v7 = CULng(CULng(Rand.Next()) * Rand.Next())

      Dim instance = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      Dim bytes = instance.ToBytes()

      bytes = instance.ToBytes(False)

      Dim values = instance.ToValues()

      values = instance.ToValues(False)
    End Sub

    Private Sub TestToString()

      Dim v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v7 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim instance = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      Dim binstr = instance.ToString(2)
      Dim octstr = instance.ToString(8)
      Dim decstr = instance.ToString(10)
      Dim hexstr = instance.ToString(16)

      Dim i128 = Int512Ex.Parse(decstr, 10)

      i128 = Int512Ex.Parse(binstr, 2)

      i128 = Int512Ex.Parse(octstr, 8)

      i128 = Int512Ex.Parse(hexstr, 16)

    End Sub

    Private Sub TestParse()
      Dim v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v7 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim instance = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      Dim ui = CUInt(instance)
      Dim ll = CLng(instance)

      Dim sng = CSng(instance)
      Dim dbl = CDbl(instance)
      Dim dec = CDec(instance)

      If ui <> Convert.ToUInt32(instance) Then Throw New ArgumentException(Nothing)
      If ll <> Convert.ToInt64(instance) Then Throw New ArgumentException(Nothing)

      If sng <> Convert.ToSingle(instance) Then Throw New ArgumentException(Nothing)
      If dbl <> Convert.ToDouble(instance) Then Throw New ArgumentException(Nothing)
      If dec <> Convert.ToDecimal(instance) Then Throw New ArgumentException(Nothing)

    End Sub

    Private Sub TestParseString()

      Dim v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v7 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim instance = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      Dim binstr = instance.ToString(2)
      Dim octstr = instance.ToString(8)
      Dim decstr = instance.ToString(10)
      Dim hexstr = instance.ToString(16)

      Dim instance_1 = Int512Ex.Parse(binstr, 2)

      Dim instance_2 = Int512Ex.Parse(octstr, 8)

      Dim instance_3 = Int512Ex.Parse(decstr, 10)

      Dim instance_4 = Int512Ex.Parse(hexstr, 16)

      'bin
      Dim bytes = Enumerable.Range(CInt(0), Rand.[Next](CInt(2), CInt(129))).[Select](Function(x) CByte(CByte(Rand.[Next](CInt(0), CInt(2))))).ToArray()
      bytes = TrimFirstSetOneZero(bytes)
      Dim bits = String.Join("", bytes)
      Dim ui128 = Int512Ex.Parse(bits, 2)
      Dim strbits = ui128.ToString(2)

      'Oct-Systeme können nicht frei gerandomt werden.
      bytes = Enumerable.Range(CInt(0), Rand.[Next](CInt(2), CInt(129))).[Select](Function(x) CByte(CByte(Rand.[Next](CInt(0), CInt(2))))).ToArray()
      bytes = TrimFirstSetOneZero(bytes)
      bits = String.Join("", bytes)
      ui128 = Int512Ex.Parse(bits, 2)

      Dim oct = ui128.ToString(8)
      bits = String.Join("", oct)
      ui128 = Int512Ex.Parse(bits, 8)
      strbits = ui128.ToString(8)


      'dec
      bytes = Enumerable.Range(CInt(0), Rand.[Next](CInt(2), CInt(38))).[Select](Function(x) CByte(CByte(Rand.[Next](CInt(0), CInt(10))))).ToArray()
      bytes = TrimFirstSetOneZero(bytes)
      bits = String.Join("", bytes)
      ui128 = Int512Ex.Parse(bits, 10)
      strbits = ui128.ToString(10)

      'Hex
      bytes = Enumerable.Range(CInt(0), Rand.[Next](CInt(2), CInt(33))).[Select](Function(x) CByte(CByte(Rand.[Next](CInt(0), CInt(16))))).ToArray()

      Dim hex = "0123456789ABCDEF"
      bytes = TrimFirstSetOneZero(bytes)
      bits = String.Join("", bytes.[Select](Function(s) hex(s)))
      ui128 = Int512Ex.Parse(bits, 16)
      strbits = ui128.ToString(16)
    End Sub

    Private Sub TestBitwiseNot()

      Dim v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v7 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim instance = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      Dim r = CULng(CULng(Rand.Next()) * Rand.Next())
      instance += r
      Dim result2 = Not instance
    End Sub

    Private Sub TestBitwiseAnd()
      Dim v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v7 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim instance = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      Dim number = CULng(CULng(Rand.Next()) * Rand.Next())
      instance += number

      Dim r = CULng(CULng(Rand.Next()) * Rand.Next())
      instance = instance And r
    End Sub

    Private Sub TestBitwiseOr()

      Dim v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v7 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim instance = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      Dim number = CULng(CULng(Rand.Next()) * Rand.Next())
      instance += number

      Dim r = CULng(CULng(Rand.Next()) * Rand.Next())

      instance = instance Or r
    End Sub

    Private Sub TestBitwiseXor()

      Dim v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v7 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim instance = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      Dim number = CULng(CULng(Rand.Next()) * Rand.Next())
      instance += number

      Dim r = CULng(CULng(Rand.Next()) * Rand.Next())
      instance = instance Xor r

    End Sub

    Private Sub TestBitwiseShift()

      Dim v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v7 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim instance = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      Dim number = CULng(CULng(Rand.Next()) * Rand.Next())
      instance += number

      Dim l = 1 + CInt(Double.Truncate(Math.Log10(Math.Pow(2, 128))))
      Dim r = Rand.[Next](0, l)
      instance <<= r

      r = Rand.[Next](0, l)
      instance >>= r

      r = Rand.[Next](0, l)
      'instance >>>= r 
      instance = Int512Ex.op_UnsignedRightShift(instance, r)
    End Sub

    Private Sub TestIsZeroOne()

      Dim v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v7 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim instance = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      If instance.IsZero Then instance += 1UI

      If instance.IsZero Then Throw New ArgumentException(Nothing)


      If instance.IsOne Then instance += 1UI

      If instance.IsOne Then Throw New ArgumentException(Nothing)


      If instance.IsMinusOne Then instance -= 1UI

      If instance.IsMinusOne Then Throw New ArgumentException(Nothing)


      instance = 0UI
      If Not instance.IsZero Then Throw New ArgumentException(Nothing)

      instance += 1UI
      If Not instance.IsOne Then Throw New ArgumentException(Nothing)

      instance -= 1UI
      instance -= 1UI
      If Not instance.IsMinusOne Then Throw New ArgumentException(Nothing)
    End Sub

    Private Sub TestIsMinMax()

      Dim v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v7 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim instance = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      If instance = Int512Ex.MaxValue Then instance += 1UI
      If instance = Int512Ex.MaxValue Then Throw New ArgumentException(Nothing)
      If instance = Int512Ex.MinValue Then instance += 1UI
      If instance = Int512Ex.MinValue Then Throw New ArgumentException(Nothing)

      instance = 0
      instance -= 1

      If instance = Int512Ex.MaxValue Then instance += 1
      If instance = Int512Ex.MaxValue Then Throw New ArgumentException(Nothing)
      If instance = Int512Ex.MinValue Then instance += 1
      If instance = Int512Ex.MinValue Then Throw New ArgumentException(Nothing)
    End Sub

    Private Sub TestEquals()

      Dim v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v7 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim instance1 = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)
      Dim instance2 = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      If Not instance1.Equals(instance2) Then Throw New ArgumentException(Nothing)

      Dim ainstance1 = New Int512Ex() {CULng(CULng(Rand.Next()) * Rand.Next()), CULng(CULng(Rand.Next()) * Rand.Next()), CULng(CULng(Rand.Next()) * Rand.Next()), CULng(CULng(Rand.Next()) * Rand.Next())}

      Dim ainstance2 = ainstance1.ToArray()

      If Not ainstance1.SequenceEqual(ainstance2) Then Throw New ArgumentException(Nothing)

      ainstance2(0) += 1

      If ainstance1.SequenceEqual(ainstance2) Then Throw New ArgumentException(Nothing)
    End Sub

    Private Sub TestGreatLessThan()

      Dim v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v7 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim instance1 = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)
      Dim instance2 = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      If Not instance1 = instance2 Then Throw New ArgumentException(Nothing)

      If instance1 >= instance2 Then
      Else
        Throw New ArgumentException(Nothing)
      End If
      instance1 += 1

      If instance1 >= instance2 Then
      Else
        Throw New ArgumentException(Nothing)
      End If

      instance1 -= 1
      instance1 -= 1

      If instance1 <= instance2 Then
      Else
        Throw New ArgumentException(Nothing)
      End If

      instance1 -= 1

      If instance1 <= instance2 Then
      Else
        Throw New ArgumentException(Nothing)
      End If

      instance1 += 10
      If instance1 > instance2 Then
      Else
        Throw New ArgumentException(Nothing)
      End If

      instance1 -= 20
      If instance1 < instance2 Then
      Else
        Throw New ArgumentException(Nothing)
      End If
    End Sub

    Private Sub TestIteration()

      Dim v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v7 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim instance = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      If instance = Int512Ex.MaxValue Then instance += 1
      If instance = Int512Ex.MaxValue Then Throw New ArgumentException(Nothing)
      If instance = Int512Ex.MinValue Then instance += 1
      If instance = Int512Ex.MinValue Then Throw New ArgumentException(Nothing)
    End Sub

    Private Sub TestAddition()

      Dim v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v7 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim instance1 = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      Dim uii = CULng(CUInt(Rand.Next()) * Rand.Next())
      instance1 += uii

      Dim lg = CLng(Rand.Next()) * Rand.Next()
      instance1 += lg
      lg = -lg
      instance1 += lg

    End Sub

    Private Sub TestSubtraction()


      Dim v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v7 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim instance1 = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      Dim uii = CUInt(CUInt(Rand.Next()) + Rand.Next())

      Dim lg = CLng(Rand.Next()) * Rand.Next()

      instance1 -= uii

      instance1 -= lg
      lg = -lg
      instance1 -= lg

    End Sub

    Private Sub TestMultiplication()


      Dim v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v7 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim instance1 = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      Dim uii = CUInt(Rand.Next())

      Dim lg = CLng(Rand.Next()) * Rand.Next()

      instance1 *= uii

      instance1 *= lg
      lg = -lg
      instance1 *= lg

    End Sub

    Private Sub TestDivision()


      Dim v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v7 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim instance1 = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      Dim uii = CUInt(Rand.Next())

      Dim lg = CLng(Rand.Next()) * Rand.Next()

      If uii = 0 Then uii = 1
      instance1 /= uii


      v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      v7 = CULng(CULng(Rand.Next()) * Rand.Next())
      instance1 = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      If lg = 0 Then lg = 1
      instance1 /= lg

      lg = -lg
      instance1 /= lg

    End Sub

    Private Sub TestModulo()


      Dim v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v7 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim instance1 = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      Dim uii = CULng(Rand.Next())

      Dim lg = CLng(CLng(Rand.Next()) * Rand.Next())

      If uii = 0 Then uii = 1
      instance1 = instance1 Mod uii

      If lg = 0 Then lg = 1
      instance1 = instance1 Mod lg
      lg = -lg
      instance1 = instance1 Mod lg

    End Sub

    Private Sub TestPow()


      Dim v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v7 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim instance = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      Dim e = Rand.[Next](0, 15)
      instance = Int512Ex.Pow(instance, e)

      e = Rand.[Next](0, 128)
      Dim overflow As Boolean
      Dim p2 = Int512Ex.PowerOfTwo(e, overflow)
      If overflow Then Throw New ArgumentException(Nothing)

      If Not Int512Ex.IsPowerTwo(p2) Then Throw New ArgumentException(Nothing)

      e = Rand.[Next](0, 39)
      Dim p10 = Int512Ex.PowerOfTen(e, overflow)
      If overflow Then Throw New ArgumentException(Nothing)

    End Sub

    Private Sub TestNegate()


      Dim v0 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v1 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v2 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v3 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v4 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v5 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v6 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim v7 = CULng(CULng(Rand.Next()) * Rand.Next())
      Dim instance = New Int512Ex(v7, v6, v5, v4, v3, v2, v1, v0)

      instance = -instance

    End Sub

    Private Function TrimFirstSetOneZero(bytes As Byte()) As Byte()

      If bytes.Length < 3 Then Return New Byte(1) {0, 1}

      Dim count = 0
      Dim length = bytes.Length
      For i = 0 To length - 1
        If bytes(i) = 0 Then
          count += 1
        Else
          Exit For
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
