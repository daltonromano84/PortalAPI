using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortalAPI.Dtos
{

public class UserResponseReadDto
{
  
public string Message { get; set; }     
public bool IsSuccess { get; set; }

public IEnumerable<string> Errors { get; set; }

public DateTime? ExpireDate { get; set; }
 
}

}