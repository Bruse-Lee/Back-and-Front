<template>
  <div>
    <el-table :data="tableData" max-height="calc(100vh - 120px)" border>
      <el-table-column fixed prop="id" label="ID" width="249"></el-table-column>
      <el-table-column
        prop="username"
        label="姓名"
        width="350"
      ></el-table-column>
      <el-table-column
        prop="password"
        label="密码"
        width="390"
      ></el-table-column>
      <el-table-column
        prop="createTime"
        label="创建时间"
        width="390"
      ></el-table-column>
      <el-table-column
        prop="updateTime"
        label="更新时间"
        width="300"
      ></el-table-column>
    </el-table>
  </div>
</template>

<script>
export default {
  created: function () {
    this.$axios.get("/user").then((res) => {
      this.tableData = res.data.data;
      console.log(res);
    });
  },
  data() {
    return {
      tableData: null,
    };
  },
};
</script>

<style scoped>
</style>


