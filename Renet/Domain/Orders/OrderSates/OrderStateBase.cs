using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders.OrderSates {
    public abstract class OrderStateBase {
        protected OrderStateBase() {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime CreateDate { get; private set; }
        public virtual OrderStateBase Confirm(User actor) {
            throw new Exception("this action not allowed");
        }

        public virtual OrderStateBase Reject(User actor) {
            throw new Exception("this action not allowed");
        }
        public virtual OrderStateBase SendToPost(User actor) {
            throw new Exception("this action not allowed");
        }
        public virtual OrderStateBase Deliver(User actor) {
            throw new Exception("this action not allowed");
        }

    }
}
