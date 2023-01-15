using System;
using Microsoft.AspNetCore.Identity;
using JobMVC.Models;

namespace JobMVC.Models.Identity
{
	public class AppUser : IdentityUser 
	{
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string FullName { get { return FirstName + " " + LastName; } }
		public string Address { get; set; } = null!;
		public string City { get; set; } = null!;
		public string State { get; set; } = null!;
		public string? Zip { get; set; }
		public string Country { get; set; } = null!;
		public string? Website { get; set; }
		public string? Company { get; set; }
		public string? Title { get; set; }
		public string? Department { get; set; }
		public string? Notes { get; set; }
		public string? Avatar { get; set; }
		public string AvatarUrl { get { return "~/assets/images" + Avatar; } }
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }
		public DateTime LastLogin { get; set; }
		public bool IsAdmin { get; set; }
		public bool IsEmployer { get; set; }
		public bool IsDeleted { get; set; }
		public bool IsLockedOut { get; set; }
		public bool IsApproved { get; set; }
		public bool IsOnline { get; set; }
		public bool IsBanned { get; set; }
		public bool IsGuest { get; set; }
		public bool IsSuspended { get; set; }
		public bool IsPending { get; set; }
		public bool IsConfirmed { get; set; }
		public bool IsUnsubscribed { get; set; }
		public bool IsPasswordExpired { get; set; }
		public bool IsPasswordReset { get; set; }
		public bool IsPasswordChanged { get; set; }
		public bool IsPasswordTemporary { get; set; }
		public bool IsPasswordValid { get; set; }
		public bool IsPasswordInvalid { get; set; }
		public bool IsPasswordCorrect { get; set; }
		public bool IsPasswordIncorrect { get; set; }
		public bool IsPasswordStrong { get; set; }
		public bool IsPasswordWeak { get; set; }
		public bool IsPasswordExpiredOrInvalid { get; set; }
	}
}

