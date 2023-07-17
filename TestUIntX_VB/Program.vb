
Option Strict On
Option Explicit On

Namespace TestUIntX

  Public Module Program

    Public Sub Main()

      TestInt128Ex.Start()
      TestUInt128Ex.Start()

      TestInt256Ex.Start()
      TestUInt256Ex.Start()

      TestInt512Ex.Start()
      TestUInt512Ex.Start()

      Console.WriteLine()
      Console.WriteLine("Finish")
      Console.WriteLine()
      Console.ReadLine()

    End Sub


  End Module

End Namespace
