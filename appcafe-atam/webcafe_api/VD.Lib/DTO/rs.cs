namespace VD.Lib.DTO
{
    public class rs
    {
        public bool r { get; set; }
        public string m { get; set; }

        public object v { get; set; }

        public rsErr err { get; set; }

        public rs()
        {
            this.r = true;
            this.m="";
        }
        public rs(bool r, string m,object v=null,rsErr _err=null)
        {
            this.r = r;
            this.m = m;
            this.v = v;
            this.err = _err;
        }
        public static rs T(string m, object v = null)
        {
            return new rs(true,m,v);
        }

        public static rs F(string m, object v = null,rsErr _err=null)
        {
            return new rs(false, m, v,_err);
        }
        public static rs Err(int status_code,string message)
        {
            rsErr _err = new rsErr()
            {
                status_code= status_code,
                message = message
            };
            return new rs(false, string.Empty, null, _err);
        }


    }

    public class ApiRS
    {
        public rs r { get; set; }
        public object value { get; set; }
    }
    public class rsErr
    {
        public int status_code { get; set; }
        public string message { get; set; }
        
        
    }
    
}