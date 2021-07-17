<template>
  <div>
    <el-card class="box-card" style="height: 70px">
      <el-form :inline="true" :model="formInline" class="demo-form-inline">
        <el-input
          v-model="formInline.user"
          placeholder="Search..."
          class="search"
        ></el-input>
        &nbsp;
        <el-button
          type="primary"
          @click="onSubmit"
          class="el-icon-search"
        ></el-button>
        &nbsp;
        <el-button @click="editAddUser()" type="primary" size="stander"
          ><i class="el-icon-circle-plus-outline"></i>
        </el-button>
        <AddUser
          :addUserVisible="addUserVisible"
          @val-change="addUser"
          @cancel="addUserVisible = false"
        ></AddUser>
      </el-form>
    </el-card>
    &nbsp;
    <el-table
      :data="tableData"
      max-height="680px"
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
          <el-button
            size="mini"
            @click="handleEdit(scope.$index, scope.row)"
            round
            ><i class="el-icon-edit"></i>编辑</el-button
          >

          <el-button
            size="mini"
            type="danger"
            @click="handleDelete(scope.$index, scope.row.id)"
            round
          >
            <i class="el-icon-delete"></i>删除</el-button
          >
        </template>
      </el-table-column>
    </el-table>
  </div>
</template>

<script>
import { GetList, deleteById } from "../../../api/user";
import request from '../../../utils/request'
import AddUser from "./add.vue";
export default {
  mounted: function () {
    GetList().then((res) => {
      this.tableData = res.data.data;
      console.log(res.data.data);
    });
  },
  data() {
    return {
      tableData: null,
      //默认为false，Dialog不显示
      addUserVisible: false,
      formInline: {
        user: "",
        region: "",
      },
    };
  },
  components: {
    AddUser,
  },
  // 注入reload方法
  // 这样就实现了子组件调取reload方法就实现了刷新vue组件的功能,这样应该是它实现了组件跨越组件传递数据方法。
  inject: ["reload"],
  methods: {
    editAddUser() {
      this.addUserVisible = true;
    },
    addUser(data) {
      console.log(data);
      let APP = this;
      let res = JSON.parse(JSON.stringify(data));
      // let result = {
      //   "Username": res.Username,
      //   "Password": res.Password,
      // };
      console.log(res);
      // console.log(result);
      request.post("/user/register",res).then((res) => {
        //所以此处打印的是用户状态信息
        console.log(res);
        console.log(res.data);
        if (res.data.code === 200) {
          alert("注册成功");
          this.addUserVisible = false
        } else {
          alert("用户名已存在,请重新尝试！");
        }
      });
      //  this.$axios.post("http://localhost:8085/user/register.do",this.$qs.stringify(this.user)).then(function(res){


      // console.log(data);
      APP.addUserVisible = true;
    },

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
    onSubmit() {},
  },
};
</script>

<style scoped>
.elTable {
  border-radius: 10px;
}
.search {
  width: 200px;
}
</style>>




