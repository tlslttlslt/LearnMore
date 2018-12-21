Imports Npgsql                      '使用PgSQL数据库所需的类库


Public Class DB_Oper_Pg

        Dim pgCnn As NpgsqlConnection


        Public Function PgConn_Open(pstgrCnnString As String) As Boolean

            pgCnn = New NpgsqlConnection()
            pgCnn.ConnectionString = pstgrCnnString
            Try
                pgCnn.Open()
                Return True
            Catch ex As Exception
                Return False
            End Try

        End Function
        Public Function PgConn_Close(pstgrCnnString As String) As Boolean
            Try
                pgCnn.Close()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Pg_S_Execute(strSelect As String) As DataSet
            Dim ds As DataSet

            'ds =




            Return ds



        End Function


    End Class












