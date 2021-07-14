<template>
  <!-- <div>
    <el-main>
      <el-table :data="tableData" style="width: 100%" max-height="250">
        <el-table-column fixed prop="id" label="ID" width="150">
        </el-table-column>
        <el-table-column prop="username" label="姓名" width="120">
        </el-table-column>
        <el-table-column prop="password" label="密码" width="120">
        </el-table-column>
        <el-table-column prop="createTime" label="创建时间" width="300">
        </el-table-column>
        <el-table-column prop="updateTime" label="更新时间" width="120">
        </el-table-column>

        <el-table-column fixed="right" label="操作" width="120">
          <template slot-scope="scope">
            <el-button
              @click.native.prevent="deleteRow(scope.$index, tableData)"
              type="text"
              size="small"
            >
              移除
            </el-button>
          </template>
        </el-table-column>
      </el-table>
    </el-main>
  </div> -->
  <div>
    <el-table :data="tableData" height="800px" border style="width: 100%">
      <el-table-column fixed prop="id" label="ID" width="150"></el-table-column>
      <el-table-column
        prop="username"
        label="姓名"
        width="120"
      ></el-table-column>
      <el-table-column
        prop="password"
        label="密码"
        width="120"
      ></el-table-column>
      <el-table-column
        prop="createTime"
        label="创建时间"
        width="300"
      ></el-table-column>
      <el-table-column
        prop="updateTime"
        label="更新时间"
        width="120"
      ></el-table-column>
    </el-table>
  </div>
</template>

<script>
export default {
  created: function () {
    this.$axios.get("http://localhost:5000/user").then((res) => {
      this.tableData = res.data.data;
      console.log(res.data.data);
    });
  },
  data() {
    return {
      tableData: null,
    };
  },
};
</script>


