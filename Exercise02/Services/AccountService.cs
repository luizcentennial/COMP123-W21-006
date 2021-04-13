using Exercise02.Models;
using Exercise02.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Exercise02.Services {
	public class AccountService : IService<Account> {
		private string directory = @"C:\_test\Accounts\";

		public List<Account> Load() {
			List<Account> accounts = null;
			var files = Directory.GetFiles(this.directory);

			if (files != null && files.Length > 0) {
				accounts = new List<Account>();

				foreach (string file in files) {
					Account account = null;
					var serializer = new XmlSerializer(typeof(Account));

					using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read)) {
						account = (Account)serializer.Deserialize(stream);
					}

					accounts.Add(account);
				}
			}

			return accounts;
		}

		public void Save(Account obj) {
			var serializer = new XmlSerializer(typeof(Account));

			using (var stream = new FileStream(this.directory + obj.AccountGuid + ".xml", FileMode.Create, FileAccess.Write)) {
				serializer.Serialize(stream, obj);
			}
		}

		public void Update(Account obj) {
			string filename = this.directory + obj.AccountGuid + ".xml";

			if (File.Exists(filename))
				File.Delete(filename);

			this.Save(obj);			
		}
	}
}
