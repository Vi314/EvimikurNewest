﻿using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Service
{
	public interface IEmployeePaymentsService
	{
		HttpStatusCode CreateRange(IEnumerable<EmployeePaymentsModel> Thing);
		HttpStatusCode UpdateRange(IEnumerable<EmployeePaymentsModel> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);
		HttpStatusCode CreateOne(EmployeePaymentsModel dealer);
		HttpStatusCode UpdateOne(EmployeePaymentsModel dealer);
		HttpStatusCode DeleteOne(int id);
		IEnumerable<EmployeePaymentsModel> GetAll();
		EmployeePaymentsModel GetById(int id);

	}
}
