using System;

public class UserAdditionalInfoModel
{
      public int UserId { get; set; }
	  public string Key { get; set; }
	  public string Value { get; set; }
	  public DateTime DateCreated { get; set; }
	  public DateTime DateRemoved { get; set; }
}
