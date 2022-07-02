<template>
  <div id="wrapper" class="wrapper">
    <h1 class="text-start">Tasks</h1>
    <TaskTable></TaskTable>

  </div>
</template>

<script>
import TaskTable from '@/components/Tasks/TaskTable';

  export default {
    name: "TaskPage",
    components: { TaskTable },
    mounted(){
      
    }
}
</script>

<style lang="scss" scoped>

</style>