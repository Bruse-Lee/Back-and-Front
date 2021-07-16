<template>
  <el-table
    :data="tableData"
    max-height="770px"
    border
    class="elTable"
    highlight-current-row
  >
    <el-table-column
      fixed
      prop="id"
      label="ID"
      width="100"
      align="center"
    ></el-table-column>
    <el-table-column
      prop="username"
      label="姓名"
      width="350"
      align="center"
    ></el-table-column>
    <el-table-column
      prop="password"
      label="密码"
      width="300"
      align="center"
    ></el-table-column>
    <el-table-column
      prop="createTime"
      label="创建时间"
      width="300"
      align="center"
    ></el-table-column>
    <el-table-column
      prop="updateTime"
      label="更新时间"
      width="300"
      align="center"
    ></el-table-column>
    <el-table-column label="操作" align="center">
      <template slot-scope="scope">
        <el-button size="mini" @click="handleEdit(scope.$index, scope.row)"
          >编辑</el-button
        >
        <el-button
          size="mini"
          type="primary"
          @click="handleAdd(scope.$index, scope.row.id)"
          >添加</el-button
        >
        <el-button
          size="mini"
          type="danger"
          @click="handleDelete(scope.$index, scope.row.id)"
          >删除</el-button
        >
      </template>
    </el-table-column>
  </el-table>
</template>

<script>
import { GetList, deleteById } from "../../../api/user";
export default {
  created: function () {
    GetList().then((res) => {
      this.tableData = res.data.data;
      console.log(res.data.data);
    });
  },
  data() {
    return {
      tableData: null,
    };
  },
  // 注入reload方法
  // 这样就实现了子组件调取reload方法就实现了刷新vue组件的功能,这样应该是它实现了组件跨越组件传递数据方法。
  inject: ["reload"],
  methods: {
    handleEdit(index, row) {
      console.log(index, row);
    },
    async handleDelete(index, id) {
      const confirmResult = await this.$confirm(
        "此操作将永久删除该用户,是否继续？",
        "提示",
        {
          confirmButtonText: "确定",
          cancelButtonText: "取消",
          type: "warning",
        }
      ).catch((err) => err);
      if (confirmResult === "confirm") {
        this.$message.success("删除成功!");
        this.tableData.splice(index, 1);
        deleteById(id);
        // this.reload()  // 调用的刷新页面方法
      } else {
        this.$message.info("取消删除!");
      }
      console.log(id);
    },
  },
};
</script>

<style scoped>
.elTable {
  border-radius: 10px;
}
</style>>




