﻿using Dapper;
using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Infra.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly IDbContext _dBContext;

		public UserRepository(IDbContext dbContext)
		{
			_dBContext = dbContext;
		}

		public void CreateNew(User user)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("p_Username", user.Username, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("p_Password", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("p_Email", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("p_VerificationCode", user.Verfiicationcode, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("p_UserStatus", user.Userstatus, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("p_RoleID", user.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);

			var result = _dBContext.Connection.Execute("USER_PACKAGE.CreateUser", parameters, commandType: CommandType.StoredProcedure);
		}

		public void Delete(int id)
		{
			var parameters = new DynamicParameters();
			parameters.Add("p_UserID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			var result = _dBContext.Connection.Execute("User_Package.DeleteUserById", parameters, commandType: CommandType.StoredProcedure);
		}

		public List<User> GetAll()
		{
			IEnumerable<User> result = _dBContext.Connection.Query<User>("User_Package.GetAllUsers", commandType: CommandType.StoredProcedure);
			return result.ToList();
		}

		public User GetById(int id)
		{
			var parameters = new DynamicParameters();
			parameters.Add("p_UserID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			IEnumerable<User> result = _dBContext.Connection.Query<User>("User_Package.GetUserById", parameters, commandType: CommandType.StoredProcedure);
			return result.FirstOrDefault();
		}

		public User GetUserByUserName(string username)
		{
            var parameters = new DynamicParameters();
			parameters.Add("User_Name", username, dbType: DbType.String, direction: ParameterDirection.Input);
			IEnumerable<User> result = _dBContext.Connection.Query<User>("User_Package.GetUserByUserName", parameters, commandType: CommandType.StoredProcedure);
			return result.FirstOrDefault();
		}

		public void Update(User user)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("p_UserID", user.Id, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("p_Username", user.Username, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("p_Password", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("p_Email", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("p_VerificationCode", user.Verfiicationcode, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("p_UserStatus", user.Userstatus, dbType: DbType.String, direction: ParameterDirection.Input);
			parameters.Add("p_RoleID", user.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);

			var result = _dBContext.Connection.Execute("USER_PACKAGE.UpdateUserByID", parameters, commandType: CommandType.StoredProcedure);
		}
	}
}
