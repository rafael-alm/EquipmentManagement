using equipmentManagement.domain.seedWork.entities.interfaces;
using equipmentManagement.domain.seedWork.objectValues;

namespace equipmentManagement.domain.seedWork.entities
{
    public abstract class EntityWithGuid : Entity<EntityIdentity>, IEntityWithGuid
    {
        public override bool Equals(object entity)
            => Id == ((EntityWithGuid)entity).Id && ReferenceEquals(this, entity);

        public override int GetHashCode()
            => base.GetHashCode();

        public override string ToString()
            => $"[{GetType().Name} Id = {Id.Value}]";
    }
}