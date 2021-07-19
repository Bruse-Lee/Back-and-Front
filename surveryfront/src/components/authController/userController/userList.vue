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
    <div class="block">
      <el-pagination
        @size-change="handleSizeChange"
        @current-change="handleCurrentChange"
        :current-page="currentPage4"
        :page-size="pager.pageIndex"
        layout="total, sizes, prev, pager, next, jumper"
        :total="pager.rowsTotal"
      >
      </el-pagination>
    </div>
  </div>
</template>

<script>
import { GetList, deleteById, newUser } from "../../../api/user";
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
      pager: {
        pageIndex: 1,
        pageSize: 10,
        rowsTotal: 50,
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
        console.log(res);
        console.log(result.data);
        if (res.data.code === 200) {
          alert("创建成功!");
          this.addUserVisible = false;
          this.reload();
        } else if (res.data.code === 104) {
          alert("请输入正确的用户名或密码!");
        } else {
          alert("用户名已存在!");
        }
      });

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
    onSubmit() {
      
    },
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




