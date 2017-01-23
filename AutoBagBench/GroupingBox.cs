using System;
using AutoBagBench.Persistence;

namespace AutoBagBench
{
    public class GroupingBox
    {
        public event IntDelegate GroupingTargetReachedEvent;
        public event IntDelegate GroupingRemainingChangedEvent;
        public virtual Guid Id { get; set; }
        public virtual Guid ProcessGuid { get; set; }
        public virtual int GroupingSize { get; set; }
        public virtual int GroupRemainingQuantity { get; set; }
        public GroupingBox(int groupingSize)
        {
           Load(groupingSize);
        }

        private GroupingBox(int groupingSize, int initialRemaining)
        {
            Load(groupingSize,initialRemaining);
        }

        public void Load(int groupingSize, int remaining)
        {
            Id = new Guid();
            GroupingSize = groupingSize;
            GroupRemainingQuantity = remaining;
        }
        public void Load(int groupingSize)
        {
            Id = new Guid();
            GroupingSize = groupingSize;
            GroupRemainingQuantity = groupingSize;
        }
        public void ProductInsert(int quantity)
        {
            if (GroupRemainingQuantity < quantity && GroupingSize > 0)
            {
                throw new Exception("Group remaining quantity is less than product Inserted quantity");
            }
            else
            {
                GroupRemainingQuantity -= quantity;

                if ((GroupRemainingQuantity == 0) && GroupingSize > 0)
                {

                    if (GroupingTargetReachedEvent != null)
                        GroupingTargetReachedEvent(GroupRemainingQuantity);
                    Reset();
                }
                if (GroupingRemainingChangedEvent != null) GroupingRemainingChangedEvent(GroupRemainingQuantity);
            }
        }
        public void ProductTake(int quantity)
        {
            
            if (GroupingSize - GroupRemainingQuantity < quantity)
            {
                throw new Exception("Not enough product in Box tobe Taken out");
            }

            GroupRemainingQuantity += quantity;
            if (GroupingRemainingChangedEvent != null) GroupingRemainingChangedEvent(GroupRemainingQuantity);
        }

     

        public void Reset()
        {
            GroupRemainingQuantity = GroupingSize;
        }


        public static GroupingBox GetRemainingFromOutputQuantity(int outputQty, int groupSize)
        {
            var j = outputQty%groupSize;
            return new GroupingBox(groupSize, groupSize - j);
        }

        public void ParseFromTotalOutput(int output)
        {
            GroupRemainingQuantity = GroupingSize>0? GroupingSize - (output%GroupingSize):GroupingSize ;
            if (output > 0 && GroupingSize > 0)
            {
                if ((output % GroupingSize ==0) && GroupingSize > 0)
                {
                    if (GroupingTargetReachedEvent != null)
                        GroupingTargetReachedEvent(GroupRemainingQuantity);
                    Reset();
                }
            }
        }
    }
}
