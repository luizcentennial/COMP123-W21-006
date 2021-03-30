using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces {
	public interface IService<T> {
		void Create(T obj);
		T GetByID(string ID);
		void Update(T obj);
		void Delete(T obj);
	}
}
