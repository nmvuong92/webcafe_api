using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VD.Data
{
    public class myDataException
    {
        public static Exception HandleException(Exception exception)
        {
            Exception exx = exception;
            DbUpdateException dbUpdateEx = exception as DbUpdateException;
            if (dbUpdateEx != null)
            {
                if (dbUpdateEx != null
                    && dbUpdateEx.InnerException != null
                    && dbUpdateEx.InnerException.InnerException != null)
                {
                    SqlException sqlException = dbUpdateEx.InnerException.InnerException as SqlException;
                    if (sqlException != null)
                    {
                        switch (sqlException.Number)
                        {
                            case 2627: // Unique constraint error
                            case 547: // Constraint check violation
                            case 2601: // Duplicated key row error
                                // Constraint violation exception
                                exx = new Exception("Dữ liệu bị trùng");
                                break;
                                // A custom exception of yours for concurrency issues

                            default:
                                // A custom exception of yours for other DB issues
                                exx = new Exception(dbUpdateEx.Message, dbUpdateEx.InnerException);
                                break;
                        }
                    }
                    else
                    {
                        exx = new Exception(dbUpdateEx.Message, dbUpdateEx.InnerException);
                    }
                }
            }
           
            // If we're here then no exception has been thrown
            // So add another piece of code below for other exceptions not yet handled...
            return exx;
        }
    }
}
