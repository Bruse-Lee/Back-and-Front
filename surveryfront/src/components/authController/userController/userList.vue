<template>
  <div>
    <el-card class="box-card" style="height: 70px">
      <el-form :inline="true" :model="formInline" class="demo-form-inline">
        <el-input
          v-model="searchText"
          placeholder="根据用户名查询..."
        ></el-input>
        &nbsp;
        <el-button
          type="primary"
          @click="onSearch"
          class="el-icon-search"
        ></el-button>
        &nbsp;
        <el-button @click="editAddUser()" type="primary" size="stander"
          ><i class="el-icon-circle-plus-outline">添加用户</i>
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
        prop="remark"
        label="备注"
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
    <p></p>
    <div class="block">
      <el-pagination
        @size-change="handlePageSizeChange"
        @current-change="handlePageIndexChange"
        :current-page="pager.pageSize"
        :page-size="pager.pageIndex"
        layout=" total,sizes, prev, pager, next, jumper"
        :total="pager.rowsTotal"
      >
      </el-pagination>
    </div>
    <!-- 修改需要使用的模态框 -->
    <el-dialog title="用户信息" :visible.sync="dialogFormVisible">
      <el-form :model="formData">
        <el-form-item label="用户名" label-width="60px">
          <el-input v-model="formData.username" autocomplete="off"></el-input>
        </el-form-item>
        <el-form-item label="密码" label-width="60px">
          <el-input v-model="formData.password" autocomplete="off"></el-input>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="handleCancel">取 消</el-button>
        <el-button type="primary" @click="handleSave">确 定</el-button>
      </div>
    </el-dialog>
  </div>
</template>

<script>
import { GetList, deleteById, newUser, changeInfo } from "../../../api/user";
import Vue from "vue";
import AddUser from "./add.vue";
import NProgress from "nprogress";
import "nprogress/nprogress.css";

const state = Vue.observable(NProgress);

export default {
  data() {
    return {
      tableData: null,
      searchList: [],
      searchText: "",
      //默认为false，Dialog不显示
      addUserVisible: false,
      pager: {
        // searchText: this.searchText,
        pageIndex: 1,
        pageSize: 10,
        rowsTotal: 0,
      },
      formInline: {
        user: "",
        region: "",
      },
      formData: {
        id: 0,
        username: "",
        password: "",
      },
      currentIndex: 1,
      dialogFormVisible: false,
      state,
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
    // 新增用户
    addUser(db) {
      // 返回的数据为__ob__: Observer：这些数据是vue这个框架对数据设置的监控器，一般都是不可枚举的
      // __ob__: Observer这个属性出现之后，如果单独拿数据的值，就会返回undefined
      let APP = this;
      // 使用下面方法进行取值
      // 先将js对象表示法(JSON)字符串转为一个对象,再将js值转换为JSON字符串
      let result = JSON.parse(JSON.stringify(db));
      newUser(result).then((res) => {
        //所以此处打印的是用户状态信息
        console.log(res.data);
        console.log(result);
        if (res.data.code === 200) {
          this.$message({
            message: "创建成功!",
            type: "success",
          });
          this.addUserVisible = false;
          // this.reload();
        } else if (res.data.code === 1000) {
          // alert("请输入正确的用户名或密码!");
          this.$confirm("请输入正确的用户名或密码!", "提示", {
            confirmButtonText: "确定",
            cancelButtonText: "取消",
            type: "warning",
          });
        }
      });

      APP.addUserVisible = true;
    },
    // 改变页码后，重新拉取数据
    handlePageIndexChange(val) {
      console.log(val);
      this.pager.pageIndex = val;
      // this.listQuery.pageSize = val;
      this.fetchData(this.pager);
      // console.log(val);
    },
    // 改变页大小后，重新拉取数据
    handlePageSizeChange(val) {
      console.log(val);
      this.pager.pageSize = val;
      // this.listQuery.pageSize = val;
      this.fetchData(this.pager);
    },
    // 拉取数据方法
    fetchData(pager) {
      GetList(pager)
        .then(({ data }) => {
          console.log(data);
          let res = data.data;
          this.tableData = res.data;
          this.pager = res.pager;
        })
        .catch((err) => {
          console.log(err);
        });
    },
    handleEdit(index, row) {
      // console.log(index, row);
      this.dialogFormVisible = true;
      this.formData.id = row.id;
      this.formData.username = row.username;
      this.formData.password = row.password;

      this.currentIndex = index;
    },
    handleCancel() {
      this.dialogFormVisible = false;
    },
    handleSave() {
      changeInfo(this.formData.id, this.formData).then(({ data }) => {
        // console.log(data);
        if (data.code === 104) {
          console.log(data);
          this.$confirm("用户名已存在!", "提示", {
            confirmButtonText: "确定",
            cancelButtonText: "取消",
            type: "warning",
          });
        } else {
          this.dialogFormVisible = false;
          this.$message({
            message: "修改成功!",
            type: "success",
          });
          this.tableData.splice(this.currentIndex, 1, data.data);
        }
      });
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
      // console.log(id);
    },
    onSearch() {
      // this.listQuery.pageIndex = 1;
      this.pager.pageIndex = 1;
      this.fetchData(this.pager);
      // var arr = this.tableData,
      //   searchText = this.searchText;
      // // console.log(arr);
      // // console.log(searchText);
      // if (!searchText) {
      //   return arr;
      // }
      // searchText = searchText.trim();
      // arr = arr.filter(
      //   (item) =>
      //     // 模糊查询
      //     item.username.indexOf(this.searchText) !== -1
      // );
      // console.log(arr);
      // this.tableData = this.arr
    },
  },

  created() {
    // this.tableData = this.arr;
  },
  mounted() {
    NProgress.start();
    setTimeout(() => {
      this.fetchData(this.pager);
      NProgress.done();
    }, 2000);
    // this.tableData = this.arr;
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




