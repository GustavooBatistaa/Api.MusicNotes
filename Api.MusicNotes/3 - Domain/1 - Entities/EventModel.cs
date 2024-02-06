﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.MusicNotes._3___Domain._1___Entities
{
	public class EventModel
	{
		public EventModel(){}

		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "Nome")]
		public string Name { get; set; }
		public void Insert(string name) => Name = name;
	}
}
