﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProtoBuf;

namespace Resgrid.Model
{
	[ProtoContract]
	[Table("CallProtocols")]
	public class CallProtocol : IEntity
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[ProtoMember(1)]
		public int CallProtocolId { get; set; }

		[Required]
		[ForeignKey("Call"), DatabaseGenerated(DatabaseGeneratedOption.None)]
		[ProtoMember(2)]
		public int CallId { get; set; }

		public virtual Call Call { get; set; }

		[Required]
		[ForeignKey("Protocol"), DatabaseGenerated(DatabaseGeneratedOption.None)]
		[ProtoMember(3)]
		public int DispatchProtocolId { get; set; }

		public virtual DispatchProtocol Protocol { get; set; }

		[ProtoMember(4)]
		public int Score { get; set; }

		[ProtoMember(5)]
		public int Trigger { get; set; }

		[ProtoMember(6)]
		public string Data { get; set; }

		[NotMapped]
		public object Id
		{
			get { return CallProtocolId; }
			set { CallProtocolId = (int)value; }
		}
	}
}
