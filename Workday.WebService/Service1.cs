using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Workday.WebService.WorkdayReference;

namespace Workday.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public Get_Applicants_ResponseType Get_Applicants(Workday_Common_HeaderType Workday_Common_Header, Get_Applicants_RequestType Get_Applicants_Request)
        {
            // Tạo một phiên bản của lớp RecruitingPortClient
            RecruitingPortClient client = new RecruitingPortClient();

            try
            {
                // Gọi các phương thức API từ dịch vụ WCF
                var result = client.Get_Applicants(Workday_Common_Header, Get_Applicants_Request);

                // Xử lý kết quả ở đây

                // Đóng kết nối
                client.Close();
                return result;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                Console.WriteLine("Error: " + ex.Message);
            }
            return null;
        }
    }
}
