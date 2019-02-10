// This class will create signatures for all the mandatory methods that needs to be implemented in every repository class.

///<summary>
///  This class will create signatures for all the mandatory methods that needs to be implemented in every repository class.
///  <remark    cref=""> TEntity Represents a table for a particular type in the underlying database </remark>
///  <see       cref="https://msdn.microsoft.com/en-us/library/bb358844(v=vs.110).aspx#Inheritance%20Hierarchy"> For more info on using <Table> object </see>
///  <seealso   cref="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/where-generic-type-constraint"> For more info about setting constraints on generics implementations.</seealso>
///</summary>
namespace DoE.Lsm.Data.Repositories
{

    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public enum ComparisonFlavor
    {
       Equal   
    }

    public interface IRepository<TEntity> where TEntity : class  //only class types can be passed as 
    {

        ///<summary>
        ///   Adds a new row to your table
        ///</summary
        void Push(TEntity entity, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "", 
                                  [System.Runtime.CompilerServices.CallerFilePathAttribute] string filePath = "", 
                                  [System.Runtime.CompilerServices.CallerLineNumberAttribute] int lineNumber = 0);

        ///<summary>
        ///</summary
        void TryPush(TEntity entity, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
                                     [System.Runtime.CompilerServices.CallerFilePathAttribute] string filePath = "",
                                     [System.Runtime.CompilerServices.CallerLineNumberAttribute] int lineNumber = 0);

        ///<summary>
        /// Adds a range of values to your table 
        ///</summary
        void PushRange(IEnumerable<TEntity> entities, 
                                             [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
                                             [System.Runtime.CompilerServices.CallerFilePathAttribute] string filePath = "",
                                             [System.Runtime.CompilerServices.CallerLineNumberAttribute] int lineNumber = 0);

        ///<summary>
        ///  Searches your tables by passing an lambda expression
        ///  <return name="IEnumerable<TEntity>"> IEnumerable<TEntity> of results se based on the condition build by the passed expression </return>
        /// <param name="Expression<Funct<TEntity,bool>>"> Lamdba expression</param>
        ///</summary
        IEnumerable<TEntity> Many(Expression<Func<TEntity, bool>> predicate, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
                                                                             [System.Runtime.CompilerServices.CallerFilePathAttribute] string filePath = "",
                                                                             [System.Runtime.CompilerServices.CallerLineNumberAttribute] int lineNumber = 0);

        TEntity Single(int id, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
                               [System.Runtime.CompilerServices.CallerFilePathAttribute] string filePath = "",
                               [System.Runtime.CompilerServices.CallerLineNumberAttribute] int lineNumber = 0);

        Task<TEntity> SingleAsync(int id, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
                                          [System.Runtime.CompilerServices.CallerFilePathAttribute] string filePath = "",
                                          [System.Runtime.CompilerServices.CallerLineNumberAttribute] int lineNumber = 0);

        void Remove(TEntity entity, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
                                    [System.Runtime.CompilerServices.CallerFilePathAttribute] string filePath = "",
                                    [System.Runtime.CompilerServices.CallerLineNumberAttribute] int lineNumber = 0);

        void RemoveRange(IEnumerable<TEntity> entities, 
                                    [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
                                    [System.Runtime.CompilerServices.CallerFilePathAttribute] string filePath = "",
                                    [System.Runtime.CompilerServices.CallerLineNumberAttribute] int lineNumber = 0);

        // Searches your tables by passing an lambda expression
        ///<summary>
        ///  Searches your tables by passing an lambda expression
        ///  <return name="IEnumerable<TEntity>"> IEnumerable<TEntity> of results se based on the condition build by the passed expression </return>
        /// <param name="Expression<Funct<TEntity,bool>>"> Lamdba expression</param>
        ///</summary
        IEnumerable<TEntity> ManyAsync(Expression<Func<TEntity, bool>> predicate, 
                                     [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
                                     [System.Runtime.CompilerServices.CallerFilePathAttribute] string filePath = "",
                                     [System.Runtime.CompilerServices.CallerLineNumberAttribute] int lineNumber = 0);
    }
}
