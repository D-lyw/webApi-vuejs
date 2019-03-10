<template>
    <div>
        <el-form ref="form" :model="form" label-width="80px">
            <h3>{{msg.Title}}</h3>
            <div v-for="(item,index) in msg.Items" :key="index">
                人数 {{msg.ItemsNum[index]}} &nbsp;&nbsp;&nbsp;<el-button plain icon="el-icon-star-off"  style="width: 65%;text-align:left;display: inline-block;margin-top:15px;margin:10px auto;" @click="ChooseItem(index)">{{item}}</el-button>
                <el-progress :percentage="msg.ItemsNum[index]" style="width: 70%;margin: auto;"></el-progress>
            </div>
            <br>
            <span style="float:left; opacity: 0.8;margin-left: 150px;"># 参与投票人数：{{totalNum}}</span>
            <!-- <span style="float: right;opacity: 0.8;">截至时间：{{msg.StopTime}}</span> -->
        </el-form>
    </div>
</template>

<script>
export default {
    name: 'voteDetail',
    props: ['ID'],
    data(){
        return {
            ItemId: this.$route.params.num,
            msg: '',
            totalNum: 0,
        }
    },
    mounted() {
        //console.log(this.$router.params.num);
        this.getItemMsg();
    },
    methods: {
        getItemMsg(){
            var data = {
                ItemId: this.ItemId
            };
            this.axios.post(this.url + '/GetItem', data)
                .then((data) => {
                    console.log(data);
                    this.msg = data.data;
                    var copy = [];
                    copy = this.msg.Items.filter(function(item){
                        return item != undefined;
                    });
                    console.log(copy);
                    this.msg.Items = [].concat(copy);
                    console.log(this.msg);
                    this.totalNum = this.msg.ItemsNum.reduce(function(a, b){
                        return a+ b;
                    })
                })
                .catch((err) => {

                })
        },

        ChooseItem(index){
            this.msg.ItemsNum[index]++;
            var data = {
                ItemId: this.ItemId,
                ItemName: this.msg.Items[index],
                ItemNameNum: this.msg.ItemsNum[index],
            }

            this.$confirm('确认参与本次在线投票?')
            .then(_ => {
                
                this.axios.post(this.url + '/UpdateItem', data)
                    .then((data) => {
                        console.log(data);
                        if(data.data == 1){
                            this.$notify({
                                title: '成功',
                                message: '你成功参与本次在线投票！',
                                type: 'success'
                            });
                        }
                    })
                    .catch((err) => {
                        this.$message.error("投票失败！！！")
                    })
               done();     
            })
            .catch(_ => {
                //this.$message.error("投票失败！")
            });
            
        }
        
    }
}
</script>

<style scoped>

</style>
