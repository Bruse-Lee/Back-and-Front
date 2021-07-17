<template>
  <el-table
    :data="
      tableData.filter(
        (data) =>
          !search || data.name.toLowerCase().includes(search.toLowerCase())
      )
    "
    style="width: 100%"
  >
    <el-table-column align="left" >
      <template slot="header">
        <el-input class="search" v-model="search" size="mini" placeholder="输入关键字搜索" />
      </template>
    </el-table-column>
  </el-table>
</template>

<script>
export default {
  data() {
    return {
      tableData: [],
      search: "",
    };
  },
};
</script>

<style scoped>
.search{
  width: 200px;
}
</style>