<template>
  <div>
    <!--  下拉菜单-->
    <el-dropdown @command="handleCommand" class="drop"
      ><!--  绑定指令,在methods里定义-->
      <span class="el-dropdown-link">
        您好:  {{showUsername}}
        <i class="el-icon-arrow-down el-icon--right"></i>
      </span>
      <div></div>
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
import Cookies from 'js-cookie'
export default {
  data() {
    return {
      username:null,
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
    handleCancel() {
      this.centerDialogVisible = false;
    },
  },
  computed:{
    showUsername(){
      return Cookies.get('username')
    }
  }
};
</script>

<style scoped>
.drop {
  /* float: right; */
}
</style>