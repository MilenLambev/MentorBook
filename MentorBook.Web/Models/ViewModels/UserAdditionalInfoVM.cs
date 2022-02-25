using System;
using MentorBook.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class UserAdditionalInfoVM
{
	public UserAdditionalInfoVM(UserAdditionalInfoModel user) 
	{
		UserId = user.UserId;
		Key = user.Key;
		Value = user.Value;
		DateCreated = user.DateCreated;
		DateRemoved = user.DateRemoved;
	}

	public int UserId { get; set; }
	public string Key { get; set; }
	public string Value { get; set; }
	public DateTime DateCreated { get; set; }
	public DateTime DateRemoved { get; set; }
}
