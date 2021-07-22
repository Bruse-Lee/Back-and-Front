<template>
  <div>
    <el-breadcrumb separator-class="el-icon-arrow-right">
      <el-breadcrumb-item :to="{ path: '/dashboard' }"
        >仪表盘</el-breadcrumb-item
      >
      <el-breadcrumb-item :to="{ path: '/home' }">首页</el-breadcrumb-item>
      <el-breadcrumb-item :to="{ path: '/userController/userList' }"
        >用户列表</el-breadcrumb-item
      >
      <el-breadcrumb-item :to="{ path: '/personalCenter/profile' }"
        >个人信息</el-breadcrumb-item
      >
      <!--  下拉菜单-->
      <el-dropdown @command="handleCommand" class="drop"
        ><!--  绑定指令,在methods里定义-->
        <span class="el-dropdown-link">
          您好
          <i class="el-icon-arrow-down el-icon--right"></i>
        </span>
        <el-dropdown-menu slot="dropdown">
          <!-- icon是修改图标 ，command是点击后传给方法的值-->
          <el-dropdown-item icon="el-icon-edit" command="edit"
            >>修改密码</el-dropdown-item
          >

          <el-dropdown-item icon="el-icon-s-operation" command="quit"
            >>退出登录</el-dropdown-item
          >
        </el-dropdown-menu>
      </el-dropdown>
      <!--  下拉菜单结束-->
    </el-breadcrumb>
    <el-dialog
      title="Tips"
      :visible.sync="centerDialogVisible"
      width="30%"
      center
    >
      <span>确定注销?</span>
      <span slot="footer" class="dialog-footer">
        <el-button @click="handleCancel">取 消</el-button>
        <el-button type="primary" @click="handleConfirm">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>


<script>
export default {
  data() {
    return {
      centerDialogVisible: false,
    };
  },
  inject: ["reload"],
  methods: {
    handleCommand(command) {
      switch (command) {
        case "edit":
          console.log("修改密码");
          break;
        case "quit": {
          console.log("退出登录");
          this.centerDialogVisible = true;
          break;
        }
      }
    },
    handleConfirm() {
      localStorage.removeItem("token");
      localStorage.removeItem("refreshToken");
      this.$router.push("/Login");
    },
    handleCancel(){
      this.centerDialogVisible=false
    }
  },
};
</script>

<style scoped>
.drop {
  float: right;
}
</style>