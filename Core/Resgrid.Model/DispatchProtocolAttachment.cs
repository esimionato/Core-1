﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resgrid.Model
{
	[Table("DispatchProtocolAttachments")]
	public class DispatchProtocolAttachment : IEntity
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int DispatchProtocolAttachmentId { get; set; }

		[Required]
		[ForeignKey("Protocol"), DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int DispatchProtocolId { get; set; }

		public virtual DispatchProtocol Protocol { get; set; }

		public string FileName { get; set; }

		public string FileType { get; set; }

		public byte[] Data { get; set; }

		[NotMapped]
		public object Id
		{
			get { return DispatchProtocolAttachmentId; }
			set { DispatchProtocolAttachmentId = (int)value; }
		}
	}
}
