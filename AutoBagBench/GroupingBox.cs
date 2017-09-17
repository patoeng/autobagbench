using System;
using System.IO;
using IniParser;
using IniParser.Model;
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
        public const string NamaFile = "Grouping.ini";

        public string ArticleNumber { get; protected set; }
        public GroupingBox(int groupingSize,string reference)
        {
           Load(groupingSize, reference);
        }
        public GroupingBox()
        {
           
            var file = new FileInfo(NamaFile);
            if (!file.Exists) return;
            var parser = new FileIniDataParser();
            var data = parser.ReadFile(NamaFile);
            Reference = data["Group"]["Reference"];
            _prevPackedQty = 0;//Convert.ToInt32(data["Group"]["Packed"]);
            ArticleNumber = data["Group"]["ArticleNumber"];
        }
        private GroupingBox(int groupingSize, int initialRemaining, string reference)
        {
            Load(groupingSize,initialRemaining,reference);
        }

        public void SetArticle(string article)
        {
            ArticleNumber = article;
            var parser = new FileIniDataParser();
            var data = new IniData();
            data["Group"]["Reference"] = Reference;
            data["Group"]["Packed"] = _prevPackedQty.ToString();
            data["Group"]["ArticleNumber"] = ArticleNumber;
            parser.WriteFile(NamaFile, data);
        }
        public void Load(int groupingSize, int remaining, string reference)
        {
            Id = new Guid();
            GroupingSize = groupingSize;
            GroupRemainingQuantity = remaining;
            Reference = reference;

        }
        public void Load(int groupingSize, string reference)
        {
            Id = new Guid();
            GroupingSize = groupingSize;
            GroupRemainingQuantity = groupingSize;
            Reference = reference;

            var parser = new FileIniDataParser();
            var data = new IniData();
            data["Group"]["Reference"] = Reference;
            data["Group"]["Packed"] = _prevPackedQty.ToString();
            data["Group"]["ArticleNumber"] = ArticleNumber;
            parser.WriteFile(NamaFile, data);
        }
        public void ProductInsert(int quantity)
        {
           
            if (GroupRemainingQuantity < quantity && GroupingSize > 0)
            {
                throw new Exception("Group remaining quantity is less than product Inserted quantity");
            }
            else
            {
                AdjustQty(quantity);
                GroupRemainingQuantity -= quantity;

                if ((GroupRemainingQuantity == 0) && GroupingSize > 0)
                {
                    GroupingTargetReachedEvent?.Invoke(GroupRemainingQuantity);
                    Reset();
                }
                GroupingRemainingChangedEvent?.Invoke(GroupRemainingQuantity);
            }
        }
        public void ProductTake(int quantity)
        {
            
            if (GroupingSize - GroupRemainingQuantity < quantity)
            {
                throw new Exception("Not enough product in Box to be Taken out");
            }
            AdjustQty(-quantity);
            GroupRemainingQuantity += quantity;
            GroupingRemainingChangedEvent?.Invoke(GroupRemainingQuantity);
        }

        public void Reset()
        {
            GroupRemainingQuantity = GroupingSize;
        }

        public static GroupingBox GetRemainingFromOutputQuantity(int outputQty, int groupSize, string reference)
        {
            var j = outputQty%groupSize;
            return new GroupingBox(groupSize, groupSize - j,reference);
        }

        public void ParseFromTotalOutput(int output)
        {
            var oldQtyPacked = QtyPacked;
            QtyPacked = output;
            var joutput = _prevPackedQty + output;
            GroupRemainingQuantity = GroupingSize>0? GroupingSize - (joutput % GroupingSize):GroupingSize ;
            if (joutput > 0 && GroupingSize > 0)
            {
                if ((joutput % GroupingSize == 0) && GroupingSize > 0 && oldQtyPacked > 0) 
                {
                    GroupingTargetReachedEvent?.Invoke(GroupRemainingQuantity);
                    Reset();
                }
            }
        }

        public void SavePrevious()
        {
            _prevPackedQty = 0;//+= QtyPacked;
            QtyPacked = 0;
            var parser = new FileIniDataParser();
            IniData data = new IniData();
            data["Group"]["Reference"] = Reference;
            data["Group"]["Packed"] = _prevPackedQty.ToString();
            data["Group"]["ArticleNumber"] = ArticleNumber;
            parser.WriteFile(NamaFile, data);
        }
        public string Reference { get; private set; }

        public int QtyPacked { get; protected set; }
        private int _prevPackedQty;

        public void SetReference(string reference)
        {
            if (Reference != reference)
            {
                ResetPackedQty();
                Reference = reference;
            }
        }
        public void ResetPackedQty()
        {
            QtyPacked = 0;
        }
        public void AdjustQty(int delta)
        {
            QtyPacked += delta;
            if (QtyPacked < 0)
            {
                QtyPacked = 0;
            }
        }
        public override string ToString()
        {
            return (QtyPacked+_prevPackedQty).ToString("000");
        }
    }
}
