<template>
    <div>
        
        <el-card class="box-card" 
            v-for="(obj, index) in msgList"
            :key="index" style="width:45%;display:inline-block;margin: 10px 8px; padding:10px;">
            <div slot="header" class="clearfix">
                <span style="text-align:left;color: orangered;font-size: 18px;">{{obj.Title}}</span>
                
                <el-switch
                    v-model="obj.Statue"
                    active-color="#13ce66" active-text="进行中" inactive-text="结束"
                    inactive-color="#ff4949" style="float:right;" :change="changeStatue(obj.Statue, obj.ItemId)">
                </el-switch>
            </div>
            <div v-for="(o, arrindex) in obj.Items" :key="o" class="text item" style="text-align:left;margin-top: 10px;" >
                {{o}} <span style="float: right;">{{obj.ItemsNum[arrindex]}}</span>
            </div>
            <!-- <el-rate
                v-model="randomArr[index % 20]"
                disabled
                show-score
                text-color="#ff9900"
                score-template="{value}">
            </el-rate> -->
        </el-card>
    </div>
</template>

<script>
export default {
    name: 'UserItem',
    data(){
        return {
            username: 'cc',
            msgList: [],
        }
    },
    mounted() {
        this.getUserItem();
    },
    methods: {
        
        getUserItem(){
            var data = {
                UserName: this.username
            };
            this.axios.post(this.url + '/GetUserItem', data)
                .then((data) => {
                    console.log(data);
                    this.msgList = data.data;
                    for(var i = 0; i< data.data.length; i++){
                        if(this.msgList[i].Statue == 1){
                            this.msgList[i].Statue = true;
                        }else{
                            this.msgList[i].Statue = false;
                        }
                    }
                })
                .catch((err) => {

                })
        },
        changeStatue(tip ,id){
            var data = {
                Statue: tip ? 1 :0,
                ItemId: id
            };
            this.axios.post(this.url + "/UpdateVote", data)
                .then((data) => {
                    console.log(data);
                    if(data.data == 1){
                        this.$message({
                            message: '操作成功',
                            type: 'success'
                        });
                    }else{
                        this.$message({
                            message: '操作失败',
                            type: 'error'
                        });
                    }
                })
                .catch((err) => {

                })
        }
    },
}
</script>