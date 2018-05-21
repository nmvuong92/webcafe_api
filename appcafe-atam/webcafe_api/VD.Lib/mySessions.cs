using System;
using System.Web;
using VD.Lib.DTO;

namespace VD.Lib
{
    /// <summary>
    /// Xử lý session
    /// </summary>
    public class mySessions
    {
        /// <summary>
        /// Gán giá trị cho session
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">Giá trị</param>
        public static void Set(string key, object value)
        {
            try
            {
                HttpContext.Current.Session[key] = value;
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

      
        /// <summary>
        /// Lấy giá trị từ session
        /// </summary>
        /// <param name="key">key</param>
        /// <returns></returns>
        public static object Get(string key)
        {
            try
            {
               
                return HttpContext.Current.Session[key];
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Xóa session
        /// </summary>
        /// <param name="key">key</param>
        public static void Clear(string key)
        {
            try
            {
                HttpContext.Current.Session[key] = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region "PERMISSION"

        /// <summary>
        /// Quyền super admin
        /// </summary>
        /// <returns></returns>
        public static bool SuperAdmin()
        {
            try
            {
                return Convert.ToBoolean(mySessions.Get("admin_super"));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gán quyền super admin
        /// </summary>
        /// <param name="enable"></param>
        public static void SetSuperAdmin(bool enable = true)
        {
            Set("admin_super", enable);
        }

        /// <summary>
        /// Quyền public
        /// </summary>
        /// <returns></returns>
        public static bool Public()
        {
            try
            {
                return Convert.ToBoolean(mySessions.Get("admin_public"));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gán quyền public
        /// </summary>
        /// <param name="enable"></param>
        public static void SetPublic(bool enable = true)
        {
            Set("admin_public", enable);
        }

        /// <summary>
        /// Quyền xóa
        /// </summary>
        /// <returns></returns>
        public static bool Delete()
        {
            try
            {
                return Convert.ToBoolean(mySessions.Get("admin_delete"));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gán quyền xóa
        /// </summary>
        /// <param name="enable"></param>
        public static void SetDelete(bool enable = true)
        {
            Set("admin_delete", enable);
        }


        /// <summary>
        /// Quyền Tạo mới
        /// </summary>
        /// <returns></returns>
        public static bool CreateNew()
        {
            try
            {
                return Convert.ToBoolean(mySessions.Get("admin_create"));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gán quyền Tạo mới
        /// </summary>
        /// <param name="enable"></param>
        public static void SetNew(bool enable = true)
        {
            Set("admin_create", enable);
        }

        /// <summary>
        /// Quyền sửa bài viết
        /// </summary>
        /// <returns></returns>
        public static bool Edit()
        {
            try
            {
                return Convert.ToBoolean(mySessions.Get("admin_edit"));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gán quyền sửa bài viết
        /// </summary>
        /// <param name="enable"></param>
        public static void SetEdit(bool enable = true)
        {
            Set("admin_edit", enable);
        }

        /// <summary>
        /// Quyền cập nhật bài viết
        /// </summary>
        /// <returns></returns>
        public static bool Update()
        {
            try
            {
                return Convert.ToBoolean(mySessions.Get("admin_update"));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gán quyền quyền sửa bài viết
        /// </summary>
        /// <param name="enable"></param>
        public static void SetUpdate(bool enable = true)
        {
            Set("admin_update", enable);
        }


        #endregion

      
    }

    public static class SessionExtensions
    {
        public static void AddItem<T>(this HttpSessionStateBase session, T item) where T : class
        {
            session[GetKey(item.GetType())] = item;
        }

        public static T GetItem<T>(this HttpSessionStateBase session) where T : class
        {
            return session[GetKey(typeof (T))] as T;
        }

        public static string GetKey(Type itemType)
        {
            return itemType.FullName;
        }
    }
}
