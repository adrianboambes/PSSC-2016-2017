//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using University.Common;
//using University.Common.Interfaces;

//namespace University.BusinessLogic
//{
//    internal static class DataAdapterService
//    {
//        private static IMapper mMapper;

//        static DataAdapterService()
//        {
//            InitializeMapper();
//        }

//        private static void InitializeMapper()
//        {
//            var mapperConfiguration = new MapperConfiguration(config =>
//            {
//                DasConfigurator.ConfigureStudents(config);
//                //DasConfigurator.ConfigureAspNetUsers(config);
//                //DasConfigurator.ConfigureUserTokens(config);
//                //DasConfigurator.ConfigureWhiteLabels(config);
//                //DasConfigurator.ConfigureVideos(config);
//                //DasConfigurator.ConfigureUserCourseCompletionStatuses(config);
//                //DasConfigurator.ConfigureUsers(config);
//                //DasConfigurator.ConfigureTickets(config);
//                //DasConfigurator.ConfigureQuizes(config);
//                //DasConfigurator.ConfigureGroups(config);
//                //DasConfigurator.ConfigureCourses(config);
//                //DasConfigurator.ConfigureCompanies(config);
//                //DasConfigurator.ConfigureColourSchemes(config);
//                //DasConfigurator.ConfigureChapters(config);
//                //DasConfigurator.ConfigureCertificates(config);
//                //DasConfigurator.ConfigureUserQuizScores(config);
//                //DasConfigurator.ConfigureCompanyCourseThreshold(config);
//                //DasConfigurator.ConfigureLicense(config);
//                //DasConfigurator.ConfigureCountries(config);
//                //DasConfigurator.ConfigureTypeRatings(config);
//                //DasConfigurator.ConfigureLicenseTypeRatingAssignment(config);
//                //DasConfigurator.ConfigureGroupCourseAssignmentData(config);
//            });
//            mapperConfiguration.AssertConfigurationIsValid();
//            mMapper = mapperConfiguration.CreateMapper();
//        }

//        #region IModel

//        /// <summary>
//        ///     Copies the object to a new entity of type <typeparamref name="TDestType" /> by mapping their properties one-to-one
//        /// </summary>
//        /// <typeparam name="TDestType">The type of returned entity</typeparam>
//        /// <param name="entity">The entity that will be copied to the new type</param>
//        /// <returns>An entity of type <typeparamref name="TDestType" /> that contains all the properties from the source object</returns>
//        public static TDestType CopyTo<TDestType>(this IEntity entity)
//            where TDestType : class
//        {
//            return entity != null ? mMapper.Map<TDestType>(entity) : null;
//        }

//        /// <summary>
//        ///     Copies the list of objects to a new list with entities of type <typeparamref name="TDestType" /> by mapping their
//        ///     properties one-to-one,
//        ///     in the same order as found in the source list
//        /// </summary>
//        /// <typeparam name="TDestType">The type of the entities in the returned list</typeparam>
//        /// <param name="entityList">The list of entities that will be copied to the new type</param>
//        /// <returns>
//        ///     A list with entities of type <typeparamref name="TDestType" /> that contain all the properties from the source
//        ///     objects
//        /// </returns>
//        public static IList<TDestType> CopyTo<TDestType>(this IEnumerable<IEntity> entityList)
//            where TDestType : class
//        {
//            return entityList != null ? mMapper.Map<IList<TDestType>>(entityList) : null;
//        }

//        #endregion

//        #region IDataAccessObject

//        /// <summary>
//        ///     Copies the object to a new entity of type <typeparamref name="TDestType" /> by mapping their properties one-to-one
//        /// </summary>
//        /// <typeparam name="TDestType">The type of returned entity</typeparam>
//        /// <param name="entity">The entity that will be copied to the new type</param>
//        /// <returns>An entity of type <typeparamref name="TDestType" /> that contains all the properties from the source object</returns>
//        public static TDestType CopyTo<TDestType>(this IDatabaseObjectEntity entity)
//            where TDestType : class
//        {
//            return entity != null ? mMapper.Map<TDestType>(entity) : null;
//        }


//        /// <summary>
//        ///     Copies the list of objects to a new list with entities of type <typeparamref name="TDestType" /> by mapping their
//        ///     properties one-to-one,
//        ///     in the same order as found in the source list
//        /// </summary>
//        /// <typeparam name="TDestType">The type of the entities in the returned list</typeparam>
//        /// <param name="entityList">The list of entities that will be copied to the new type</param>
//        /// <returns>
//        ///     A list with entities of type <typeparamref name="TDestType" /> that contain all the properties from the source
//        ///     objects
//        /// </returns>
//        public static IList<TDestType> CopyTo<TDestType>(this IEnumerable<IDatabaseObjectEntity> entityList)
//            where TDestType : class
//        {
//            return entityList != null ? mMapper.Map<IList<TDestType>>(entityList) : null;
//        }

//        #endregion
//    }
//}
