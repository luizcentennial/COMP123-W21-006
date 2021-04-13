using Exercise02.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise02.Services.Interfaces {
	public interface IService<T> {
		public void Save(T obj);
		public List<T> Load();
		public void Update(T obj);
	}
}
