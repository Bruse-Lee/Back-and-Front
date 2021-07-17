<script>
import { GetList, deleteById } from "../../../api/user";
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
      let APP = this;
      APP.$Api.addUser(data, function () {
        console.log(data);
        APP.addUserVisible = true;
      });
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
  },
};
</script>

<style scoped>
.elTable {
  border-radius: 10px;
}
</style>