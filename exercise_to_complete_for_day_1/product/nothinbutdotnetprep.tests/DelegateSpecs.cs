 
using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetprep.infrastructure.events;

namespace nothinbutdotnetprep.tests
{
    public class DelegateSpecs
    {
        public abstract class concern : observations_for_a_static_sut
        {

        }

        [Concern(typeof (Delegate))]
        public class when_asked_to_rethrow_all_exceptions_as_argumentexceptions : concern
        {
            context c = () =>
            {
                inner_exception = new NotImplementedException();

                do_something = delegate
                {
                    throw inner_exception;
                };
            };

            because b = () =>
            {

                result =new Running(do_something).get_resulting_exception();
            };


            it should_throw_any_resulting_exception_as_an_argument_exception = () =>
            {
               result.should_be_an_instance_of<ArgumentException>()
                   .InnerException.should_be_equal_to(inner_exception);
            };

            static Exception result;
            static Exception inner_exception;
        	static Action do_something;
        }
    }
}
