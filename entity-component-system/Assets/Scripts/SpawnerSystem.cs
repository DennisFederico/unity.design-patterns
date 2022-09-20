using Unity.Jobs;
using Unity.Burst;
using Unity.Entities;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Transforms;

[UpdateInGroup(typeof(SimulationSystemGroup))]
public partial class SpawnerSystem : SystemBase {

BeginInitializationEntityCommandBufferSystem m_ECBS;

    protected override void OnCreate() {
        m_ECBS = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate() {
        var commandBuffer = m_ECBS.CreateCommandBuffer();

        Entities            
            .WithName("SpawnerSystem")
            .WithBurst(FloatMode.Default, FloatPrecision.Standard, true)
            .ForEach((Entity entity, in SpawnerData data, in LocalToWorld local2World) =>
                {
                    for (int x = 0; x < data.Ecols; x++) {
                        for (int z = 0; z < data.Erows; z++) {
                            var instance = commandBuffer.Instantiate(entity);
                            var position = math.transform(local2World.Value, new float3(x, noise.cnoise( new float2(x * 0.21f, z * 0.21f)), z));
                            commandBuffer.SetComponent(instance, new Translation { Value = position });
                        }
                    }
                    commandBuffer.DestroyEntity(entity);
                }
            ).ScheduleParallel();
        m_ECBS.AddJobHandleForProducer(Dependency);
    }
}
