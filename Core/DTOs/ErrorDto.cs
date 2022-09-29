using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
	public class ErrorDto
	{
        public List<String> Errors { get; private set; } = new List<string>();
        //Kullanıcıya hatayı göstermek için IsShow property ekledik.
        public bool IsShow { get; private set; }
        public ErrorDto(string error, bool isShow)
        {
            Errors.Add(error);
            IsShow = isShow;
        }
        public ErrorDto(List<string> errors, bool isShow)
        {
            Errors = errors;
            IsShow = isShow;
        }
    }
}
