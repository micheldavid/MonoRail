// Copyright 2004-2011 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Castle.MonoRail.Views.Brail.TestSite.Controllers
{
	using System.Collections;

	using Castle.MonoRail.Framework;

    public class UsingComponent2Controller : SmartDispatcherController
	{
		public void ComponentWithInvalidSections()
		{
		}

		public void GridComponent1()
		{
			FillPropertyBag();
		}

		public void GridComponent2()
		{
            PropertyBag.Add("contacts", new ArrayList());
		}
	
		private void FillPropertyBag()
		{
			var items = new ArrayList
			{
				new Contact("hammett", "111"), 
				new Contact("Peter Griffin", "222")
			};

			PropertyBag.Add("contacts", items);
		}
	}
	
	public class Contact
	{
		public string Email { get; set; }

		public string Phone { get; set; }

		public Contact(string email, string phone)
		{
			this.Email = email;
			this.Phone = phone;
		}
	}
}
