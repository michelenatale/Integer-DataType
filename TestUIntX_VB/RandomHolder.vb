Option Strict On
Option Explicit On


Namespace TestUIntX
  Public Module RandomHolder
    'In practice, a crypto-random must be used.
    Public ReadOnly Rand As New Random
  End Module
End Namespace